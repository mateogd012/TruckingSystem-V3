using System.ComponentModel.DataAnnotations;

namespace TruckingSystem_V3.Models
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
