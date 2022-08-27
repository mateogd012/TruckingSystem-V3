namespace TruckingSystem_V3.Models
{
    public class TruckerDto
    {
        public int Id { get; set; }
        public string NameAndLastName { get; set; } = string.Empty;
        public string? TruckerType { get; set; }

        public ICollection<TripDto> Trip { get; set; } = new List<TripDto>(); //Lo seteamos a una nueva colección para evitar que retorne un null en algún momento de la ejecución.

        public List<TripDto> Trips { get; internal set; }
    }
}
