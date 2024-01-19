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
        public List<Group> Groups {get; set; }

       public Event Event {get; set;}

        public async void OnGet()
        {
            SeatingService _seatingService = new();
            VisitorService _visitorService = new();
            Event = new(DateTime.Today, 30);
            Visitors = await _visitorService.GenerateRandomVisitors(40);
            Event.RegisterVisitors(Visitors);
            Event.ProcessEventAccess();
            Visitors = Event.RegisteredVisitors;
            Sections = _seatingService.GenerateEventSeating();
            Groups = _visitorService.GenerateGroups(Visitors);            
            Groups = _seatingService.AssignGroupsToSeats(Groups, Sections);
            
            //Visitors = _visitorService.UpdateVisitorIds(Groups, Visitors);  

        }

        
    }
}