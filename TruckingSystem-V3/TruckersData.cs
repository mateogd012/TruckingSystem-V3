using TruckingSystem_V3.Models;

namespace TruckingSystem_V3
{
    public class TruckersData
    {
        public List<TruckerDto> Truckers { get; set; }

        public TruckersData()
        {
            Truckers = new List<TruckerDto>()
            {
                new TruckerDto()
                {
                     Id = 1,
                     NameAndLastName = "Rodrigo Fernandez",
                     TruckerType = "Cisterna.",
                     Trips = new List<TripDto>()
                     {
                         new TripDto() {
                             Id = 1,
                             SourceAndDestiny = "Rosario a Buenos Aires",
                             Description = "400 Km de distancia." },
                          new TripDto() {
                             Id = 2,
                             SourceAndDestiny = "Galvez a Funes",
                             Description = "50 Km de distancia." },
                     }
                },
                new TruckerDto()
                {
                    Id = 2,
                    NameAndLastName = "Antionio Gimenez",
                    TruckerType = "Carga Seca.",
                    Trips = new List<TripDto>()
                     {
                         new TripDto() {
                             Id = 3,
                             SourceAndDestiny = "Fisherton a Buenos Aires",
                             Description = "300 Km de distancia." },
                          new TripDto() {
                             Id = 4,
                             SourceAndDestiny = "Funes a Rosario",
                             Description = "70 Km de distancia." },
                     }
                },
                new TruckerDto()
                {
                    Id= 3,
                    NameAndLastName = "Lucas Lopez",
                    TruckerType = "Carga Refrigerada.",
                    Trips = new List<TripDto>()
                     {
                         new TripDto() {
                             Id = 5,
                             SourceAndDestiny = "Capitan Bermudez a Rosario",
                             Description = "30 Km de distancia." },
                          new TripDto() {
                             Id = 6,
                             SourceAndDestiny = "Funes a Buenos Aires",
                             Description = "300 Km de distancia." },
                     }
                }
            };
        }
    }
}
