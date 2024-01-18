using VisitorPlacementModels;

namespace VisitorPlacementLogic
{
    public class SeatingService
    {
        Random r = new Random();
        
        public List<Section> GenerateEventSeating(int visitors = 10)
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


        public List<Group> AssignGroupsToSeats(List<Group> groups, List<Section> sections)
        {
            int groupIndex = 0;

            foreach (var section in sections)
            {
                int rowIndex = 1;

                while (groupIndex < groups.Count)
                {
                    var currentGroup = groups[groupIndex];

                    foreach (var currentVisitor in currentGroup.Visitors)
                    {
                        if (rowIndex <= section.Rows)
                        {
                            for (int seat = 1; seat <= section.SeatsPerRow; seat++)
                            {
                                currentVisitor.SectionName = section.Name;
                                currentVisitor.RowNumber = rowIndex;
                                currentVisitor.SeatNumber = seat;
    
                            }
                            rowIndex++;
                        }
                    }

                    groupIndex++;
                }
            }

            return groups;
        }




    }

}