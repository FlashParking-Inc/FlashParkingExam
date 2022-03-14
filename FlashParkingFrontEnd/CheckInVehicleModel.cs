namespace FlashParking
{
    public class CheckInVehicleModel
    {
        public string GarageName { get; set; }
        public string SectionName { get; set; }
        public string SpaceName { get; set; }
        public Guid SpaceId { get; set; }
        public Guid? VehicleId { get; set; }
    }
}