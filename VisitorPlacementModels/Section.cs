namespace VisitorPlacementModels
{
    public class Section
    {
        public string Name { get; set; }
        public int Rows { get; set; }
        public int SeatsPerRow { get; set; }
        public int TotalSeats => SeatsPerRow * Rows;

    }
}