using System.ComponentModel.DataAnnotations;
using TruckingSystem_V3.Enums;

namespace TruckingSystem_V3.Models
{
    public class TripToCreateDto
    {
        [Required(ErrorMessage = "Agregá un nombre")]
        [MaxLength(50)]
        public string SourceAndDestiny { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Descripcion { get; set; }

    }
}
