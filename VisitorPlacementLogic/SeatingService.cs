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
            new Section { Name = "A", Rows = r.Next(1, 4), SeatsPerRow = r.Next(3, 11) },
            new Section { Name = "B", Rows = r.Next(1, 4), SeatsPerRow = r.Next(3, 11) },
            new Section { Name = "C", Rows = r.Next(1, 4), SeatsPerRow = r.Next(3, 11) },
            new Section { Name = "D", Rows = r.Next(1, 4), SeatsPerRow = r.Next(3, 11) },
        };

            return sections;
        }


        public List<Visitor> AssignVisitorsToSeats(List<Visitor> visitors, List<Section> sections)
        {
            int visitorIndex = 0;

            foreach (var section in sections)
            {
                for (int row = 1; row <= section.Rows; row++)
                {
                    for (int seat = 1; seat <= section.SeatsPerRow; seat++)
                    {
                        if (visitorIndex < visitors.Count)
                        {
                            visitors[visitorIndex].SectionName = section.Name;
                            visitors[visitorIndex].RowNumber = row;
                            visitors[visitorIndex].SeatNumber = seat;
                            visitorIndex++;
                        }
                    }
                }
            }

            return visitors;
        }

    }

}