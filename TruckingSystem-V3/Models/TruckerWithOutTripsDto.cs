namespace TruckingSystem_V3.Models
{
    public class TruckerWithOutTripsDto
    {
        public int Id { get; set; }
        public string NameAndLastName { get; set; } = string.Empty;
        public string? TruckerType { get; set; }
    }
}
