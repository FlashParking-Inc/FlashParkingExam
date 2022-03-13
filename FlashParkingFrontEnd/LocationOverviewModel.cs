namespace FlashParking
{
    public class LocationOverviewModel
    {
        public Guid LocationId { get; set; }
        public string Name { get; set; }
        public int OpenSpots { get; set; }
        public int FilledSpots { get; set; }
        public int TotalSpots { get; set; }
    }
}
