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
        foreach (var group in groups)
        {
            foreach (var visitor in group.Visitors)
            {
                var seat = FindAvailableSeat(sections);

                if (seat != null)
                {
                    visitor.AssignSeat(seat);
                    seat.Occupied = true;
                }
                else
                {
                    // Handle case where no seat is available
                }
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