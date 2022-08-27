using System.ComponentModel.DataAnnotations;
using TruckingSystem_V3.Enums;

namespace TruckingSystem_V3.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(32)]
        public string? Name { get; set; }
        [MaxLength(32)]
        public string? LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        public UserTypes Role { get; set; }

    }
}
