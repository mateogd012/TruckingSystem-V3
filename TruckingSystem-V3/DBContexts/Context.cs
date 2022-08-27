using TruckingSystem_V3.Entities;
using Microsoft.EntityFrameworkCore;
using TruckingSystem_V3.Enums;
using TruckingSystem.Services;

namespace TruckingSystem_V3.DBContexts
{
    public class Context : DbContext
    {
        public DbSet<Trucker> Truckers { get; set; } //lo que hagamos con LINQ sobre estos DbSets lo va a transformar en consultas SQL
        public DbSet<Trip> Trips { get; set; } //Los warnings los podemos obviar porque DbContext se encarga de eso.
        public DbSet<User> Users { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Ciudad>().HasMany(c => c.PuntosDeInteres).WithOne(p => p.Ciudad).HasForeignKey(c => c.TruckerId);

            var truckers = new Trucker[3]
            {
                new Trucker("Rodrigo Fernandez")
                {
                    Id = 1,
                    TruckerType = "Cisterna.",
                },
                new Trucker("Antionio Gimenez")
                {
                    Id = 2,
                    TruckerType = "Carga Seca.",

                },
                new Trucker("Lucas Lopez")
                {
                    Id = 3,
                    TruckerType = "Carga Refrigerada.",
                }
            };
            modelBuilder.Entity<Trucker>().HasData(truckers);

            modelBuilder.Entity<Trip>().HasData(
                new Trip("Rosario a Buenos Aires")
                {
                    Id = 1,
                    Description = "400 Km de distancia.",
                    TruckerId = truckers[0].Id
                },
                new Trip("Galvez a Funes")
                {
                    Id = 2,
                    Description = "50 Km de distancia.",
                    TruckerId = truckers[0].Id
                },

                new Trip("Fisherton a Buenos Aires")
                {
                    Id = 3,
                    Description = "350 Km de distacnia.",
                    TruckerId = truckers[1].Id
                },
                new Trip("Funes a Rosario")
                {
                    Id = 4,
                    Description = "70 Km de distancia.",
                    TruckerId = truckers[1].Id
                },
                new Trip("Capitan Bermudez a Rosario")
                {
                    Id = 5,
                    Description = "30 Km de distancia.",
                    TruckerId = truckers[2].Id
                },
                new Trip("Funes a Buenos Aires")
                {
                    Id = 6,
                    Description = "300 Km de distancia.",
                    TruckerId = truckers[2].Id
                });


            var users = new User[3] {
                new User()
                {
                    Id = 1,
                    Name = "Felipe",
                    LastName = "Regis",
                    Password = "feli99",
                    UserName = "feliregis",
                    Role = UserTypes.administrator

                },
                 new User()
                {
                    Id = 2,
                    Name = "Mateo",
                    LastName = "Garcia",
                    Password = "mateo99",
                    UserName = "mategarcia",
                    Role = UserTypes.administrator

                },
                  new User()
                {
                    Id = 3,
                    Name = "Gabriel",
                    LastName = "Urushima",
                    Password = "gabi99",
                    UserName = "gabiurushima",
                    Role = UserTypes.administrator

                }

            };


            modelBuilder.Entity<User>().HasData(users);


            base.OnModelCreating(modelBuilder);
        }

        public static implicit operator Context(InfoTruckersRepository v)
        {
            throw new NotImplementedException();
        }
    }
}