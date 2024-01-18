namespace VisitorPlacementModels
{
   public class Section
{
    public string Name { get; }
    public List<Row> Rows { get; }

    public Section(string name, int rowCount, int seatsPerRow)
    {
        Name = name;
        Rows = new List<Row>();
        for (int i = 1; i <= rowCount; i++)
        {
            Rows.Add(new Row(i, seatsPerRow, this));
        }
    }

    public Seat FindAvailableSeat()
    {
        foreach (var row in Rows)
        {
            var seat = row.FindAvailableSeat();
            if (seat != null)
            {
                return seat;
            }
        }
        return null;
    }
}
}