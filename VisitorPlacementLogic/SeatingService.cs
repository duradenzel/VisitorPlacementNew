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
                    var seat = FindAvailableSeat(sections);

                    if (seat != null)
                    {
                        child.AssignSeat(seat);
                        seat.Occupied = true;                      

                    }
                    else{}
                }
                  if (adults.Any())
                {
                    var adult = adults.First();
                    var nextSeat = FindAvailableSeat(sections);

                    if (nextSeat != null)
                    {
                        adult.AssignSeat(nextSeat);
                        nextSeat.Occupied = true;
                        adults.Remove(adult);
                    }
                    else{}
                }
                
            }
            return groups;
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