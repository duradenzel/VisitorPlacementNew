﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementModels
{   
    public class Visitor
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public DateTime DateOfBirth { get; set; } 
        public bool IsAdult { get; set; } 
        public int GroupId { get; set; }
        public int SeatNumber { get; set; }

        public int RowNumber { get; set; } 
        public string SectionName { get; set; } 

        public DateTime RegistrationDate { get; set; }

        public bool IsAllowedAccess { get; set; }

        public void AssignSeat(Seat seat)
        {
            SectionName = seat.Row.Section.Name;
            RowNumber = seat.Row.Number;
            SeatNumber = seat.Number;
        }

    } 
}
