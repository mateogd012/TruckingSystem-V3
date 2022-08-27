using System.ComponentModel.DataAnnotations;
using TruckingSystem_V3.Enums;

namespace TruckingSystem_V3.Models
{
    public class TripToCreateDto
    {
        [Required(ErrorMessage = "Agrega una id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Agregá un nombre")]
        [MaxLength(50)]
        public string SourceAndDestiny { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Description { get; set; }
        public TripStatus TripStatus { get; set; }
    }
}
