using VisitorPlacementLogic;
using VisitorPlacementModels;

namespace VisitorPlacementTests;

[TestClass]
public class SeatingTests
{
    [TestMethod]
    public void GenerateEventSeating_ReturnsSectionsWithValidRowsAndSeatsPerRow()
    {

        SeatingService seatingService = new SeatingService();
       
        var sections = seatingService.GenerateEventSeating();
        int sectionCount = 4;


        Assert.AreEqual(sectionCount, sections.Count);
        foreach (var section in sections)
        {
            Assert.IsTrue(section.Rows.Count > 0 && section.Rows[0].Seats.Count > 0);
        }
    }

    [TestMethod]
    public void AssignGroupsToSeats_PlacesVisitorsInSections()
    {
        // Arrange
        SeatingService seatingService = new SeatingService();
        List<Group> groups = new List<Group>
        {
            new Group
            {
                Id = 1,
                Visitors = new List<Visitor>
                {
                    new Visitor { Id = 1, Name = "Denzel", IsAdult = true, RegistrationDate = DateTime.Now },
                    new Visitor { Id = 2, Name = "Dion", IsAdult = false, RegistrationDate = DateTime.Now },
               
                    
                },
                RegistrationDate = DateTime.Now
            },
            
        };

        List<Section> sections = new List<Section>
        {
            new Section("A", 3, 6),
             new Section("B", 2, 6),
            
        };

        
        var assignedGroups = seatingService.AssignGroupsToSeats(groups, sections);

       
        foreach (var group in assignedGroups)
        {
            foreach (var visitor in group.Visitors)
            {
                Assert.IsTrue(visitor.RowNumber > 0 && visitor.SeatNumber > 0);
            }
        }
    }

    [TestMethod]
    public void FindAvailableSeat_ReturnsAvailableSeat()
    {
    
        SeatingService seatingService = new SeatingService();
        Section section = new Section("A",3,4);
        section.Rows[1].Seats[2].Occupied = true;

        var availableSeat = section.FindAvailableSeat();

        Assert.IsNotNull(availableSeat);
        Assert.IsFalse(availableSeat.Occupied);
    }

    [TestMethod]
      public void FindAvailableSeat_ReturnsNullIfNoAvailableSeat()
    {

        Section section = new Section("A",1,3);
        section.Rows[0].Seats[0].Occupied = true;
        section.Rows[0].Seats[1].Occupied = true; 
        section.Rows[0].Seats[2].Occupied = true;  

        
        var availableSeat = section.FindAvailableSeat();

        
        Assert.IsNull(availableSeat);
    }
    
    
}