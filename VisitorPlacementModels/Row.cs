using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementModels
{
    public class Row
{
    public int Number { get; }
    public List<Seat> Seats { get; }
    public Section Section { get; }

    public Row(int number, int seatCount, Section section)
    {
        Number = number;
        Seats = new List<Seat>();
        Section = section;
        for (int i = 1; i <= seatCount; i++)
        {
            Seats.Add(new Seat(i, this));
        }
    }

    public Seat FindAvailableSeat()
    {
        return Seats.FirstOrDefault(seat => !seat.Occupied);
    }
}
}
