﻿using Microsoft.AspNetCore.Mvc;
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

        public int TotalSeats { get; set; }

        public async void OnGet()
        {
            SeatingService _seatingService = new();
            VisitorService _visitorService = new();
            
            Visitors = await _visitorService.GenerateRandomVisitors(40);
            Sections = _seatingService.GenerateEventSeating(Visitors.Count);
            Groups = _visitorService.GenerateGroups(Visitors);
            TotalSeats = Sections.Sum(s => s.TotalSeats);
            Groups = _seatingService.AssignGroupsToSeats(Groups, Sections);
                      
        }

        
    }
}