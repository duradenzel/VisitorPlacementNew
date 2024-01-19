using VisitorPlacementModels;

namespace VisitorPlacementLogic
{
    public class SeatingService
    {
        Random r = new Random();
        
        public List<Section> GenerateEventSeating()
        {
            var sections = new List<Section>
            {
                new Section("A", r.Next(1, 4), r.Next(3, 11)),
                new Section("B", r.Next(1, 4), r.Next(3, 11)),
                new Section("C", r.Next(1, 4), r.Next(3, 11)),
                new Section("D", r.Next(1, 4), r.Next(3, 11)),
            };

            return sections;
        }


       public List<Group> AssignGroupsToSeats(List<Group> groups, List<Section> sections)
        {
            groups = groups.OrderByDescending(g => g.RegistrationDate).ToList();
            foreach (var group in groups)
            {
                var children = group.Visitors.Where(v => !v.IsAdult).ToList();
                var adults = group.Visitors.Where(v => v.IsAdult).ToList();

                foreach (var child in children)
                {                
                   PlaceVisitor(child, sections);
                }
                  if (adults.Any() && children.Any())
                {
                    var adult = adults.First();
                    PlaceVisitor(adult, sections);
                    adults.Remove(adult);

                }
            }
                foreach (var group in groups)
                {
                    var remainingAdults = group.Visitors.Where(v => v.IsAdult && !(v.SeatNumber > 0)).ToList();
                    foreach (var adult in remainingAdults)
                    {
                        PlaceVisitor(adult, sections);
                    }
                }

            return groups;
        }

         private void PlaceVisitor(Visitor visitor, List<Section> sections)
        {  
                var seat = FindAvailableSeat(sections);

                if (seat != null)
                {
                    visitor.AssignSeat(seat);
                    seat.Occupied = true;
                }
            
        }

        private Seat FindAvailableSeat(List<Section> sections)
        {
            foreach (var section in sections)
            {
                var seat = section.FindAvailableSeat();
                if (seat != null)
                {
                    return seat;
                }
            }

            return null;
        }
    }

}