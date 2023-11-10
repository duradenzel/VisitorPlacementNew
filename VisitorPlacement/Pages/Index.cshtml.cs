using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VisitorPlacementLogic;
using VisitorPlacementModels;

namespace VisitorPlacement.Pages
{
    public class IndexModel : PageModel
    {
        public List<Section> Sections { get; set; }
        public List<Visitor> Visitors { get; set; }

        public int TotalSeats { get; set; }

        public void OnGet()
        {
            SeatingService _seatingService = new();
            VisitorService _visitorService = new();
            


            Sections = _seatingService.GenerateEventSeating();
            Visitors = _visitorService.GenerateRandomVisitors(40);
            Visitors = _seatingService.AssignVisitorsToSeats(Visitors, Sections);
             TotalSeats = Sections.Sum(s => s.TotalSeats);
            
            
        }
    }
}