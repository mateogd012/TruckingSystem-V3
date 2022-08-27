using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using TruckingSystem_V3.Enums;

namespace TruckingSystem_V3.Entities
{
    public class Trip
    {
        [Key] //Esto es opcional si se sigue la convención
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //También por convención no hace falta. Identity genera un nuevo Id por cada creación.
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string SourceAndDestiny { get; set; }

        [MaxLength(50)]
        public string? Description { get; set; } //Agregarlo en la segunda migración para ver como funciona la actualización.

        [ForeignKey("TruckerId")]
        public Trucker? Trucker { get; set; }
        public int TruckerId { get; set; }
        public Trip(string sourceAndDestiny)
            {
             SourceAndDestiny = sourceAndDestiny;
            }
        }
    }
