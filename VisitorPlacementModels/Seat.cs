using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementModels
{
   public class Seat
{
    public int Number { get; }
    public bool Occupied { get; set; }
    public Row Row { get; }

    public Seat(int number, Row row)
    {
        Number = number;
        Row = row;
    }
}
}
