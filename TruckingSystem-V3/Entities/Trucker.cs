using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TruckingSystem_V3.Entities
{
    public class Trucker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string NameAndLastName { get; set; }
        public string TruckerType { get; set; }
        public ICollection<Trip> Trips { get; set; } = new List<Trip>(); //Lo seteamos a una nueva colección para evitar que retorne un null en algún momento de la ejecución.

        public Trucker(string nameAndLastName)
        {
            NameAndLastName = nameAndLastName.Trim();
        }
    }
}
