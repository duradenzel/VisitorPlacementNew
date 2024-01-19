using VisitorPlacementLogic;
using VisitorPlacementModels;

namespace VisitorPlacementTests;

[TestClass]
public class VisitorTests
{
    [TestMethod]
    public async Task GenerateRandomVisitors_ReturnsCorrectNumberOfVisitors()
    {
        VisitorService visitorService = new VisitorService();
        int count = 10;

        var visitors = await visitorService.GenerateRandomVisitors(count);

        Assert.AreEqual(count, visitors.Count);
    }

    [TestMethod]
    public void GenerateGroups_ReturnsGroupsWithCorrectSize()
    {
        
        VisitorService visitorService = new VisitorService();
        List<Visitor> visitors = new List<Visitor>
        {
            new Visitor { Id = 1, Name = "Denzel", IsAdult = true, RegistrationDate = DateTime.Now },
            new Visitor { Id = 2, Name = "Dion", IsAdult = false, RegistrationDate = DateTime.Now },
        };

        
        var groups = visitorService.GenerateGroups(visitors);

        
        Assert.IsTrue(groups.All(g => g.Visitors.Count > 0 && g.Visitors.Count <= 8));
    }

    [TestMethod]
    public void AssignSeat_SetsRowAndSeatNumberForVisitor()
    {
        VisitorService visitorService = new VisitorService();
        Visitor visitor = new Visitor();
        Seat seat = new(2, new Row(1,8, new Section("A",3,8)));

        visitor.AssignSeat(seat); 

        Assert.AreEqual(1, visitor.RowNumber);
        Assert.AreEqual(2, visitor.SeatNumber);
        Assert.AreEqual("A", visitor.SectionName);
    }
}