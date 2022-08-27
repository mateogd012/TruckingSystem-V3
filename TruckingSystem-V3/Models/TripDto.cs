using TruckingSystem_V3.Enums;

namespace TruckingSystem_V3.Models
{
    public class TripDto
    {
        public int Id { get; set; }
        public string SourceAndDestiny { get; set; }
        public string? Description { get; set; }

    }
}
