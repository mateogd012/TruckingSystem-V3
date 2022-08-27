using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckingSystem_V3.Migrations
{
    public partial class TruckingSystemMigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Truckers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameAndLastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TruckerType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truckers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SourceAndDestiny = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    TripStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    TruckerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Truckers_TruckerId",
                        column: x => x.TruckerId,
                        principalTable: "Truckers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Truckers",
                columns: new[] { "Id", "NameAndLastName", "TruckerType" },
                values: new object[] { 1, "Rodrigo Fernandez", "Cisterna." });

            migrationBuilder.InsertData(
                table: "Truckers",
                columns: new[] { "Id", "NameAndLastName", "TruckerType" },
                values: new object[] { 2, "Antionio Gimenez", "Carga Seca." });

            migrationBuilder.InsertData(
                table: "Truckers",
                columns: new[] { "Id", "NameAndLastName", "TruckerType" },
                values: new object[] { 3, "Lucas Lopez", "Carga Refrigerada." });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "LastName", "Name", "Password", "Role", "UserName" },
                values: new object[] { 1, "Regis", "Felipe", "feli99", 0, "feliregis" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "LastName", "Name", "Password", "Role", "UserName" },
                values: new object[] { 2, "Garcia", "Mateo", "mateo99", 0, "mategarcia" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "LastName", "Name", "Password", "Role", "UserName" },
                values: new object[] { 3, "Urushima", "Gabriel", "gabi99", 0, "gabiurushima" });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "SourceAndDestiny", "TripStatus", "TruckerId" },
                values: new object[] { 1, "400 Km de distancia.", "Rosario a Buenos Aires", 0, 1 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "SourceAndDestiny", "TripStatus", "TruckerId" },
                values: new object[] { 2, "50 Km de distancia.", "Galvez a Funes", 0, 1 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "SourceAndDestiny", "TripStatus", "TruckerId" },
                values: new object[] { 3, "350 Km de distacnia.", "Fisherton a Buenos Aires", 0, 2 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "SourceAndDestiny", "TripStatus", "TruckerId" },
                values: new object[] { 4, "70 Km de distancia.", "Funes a Rosario", 0, 2 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "SourceAndDestiny", "TripStatus", "TruckerId" },
                values: new object[] { 5, "30 Km de distancia.", "Capitan Bermudez a Rosario", 0, 3 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "SourceAndDestiny", "TripStatus", "TruckerId" },
                values: new object[] { 6, "300 Km de distancia.", "Funes a Buenos Aires", 0, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TruckerId",
                table: "Trips",
                column: "TruckerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Truckers");
        }
    }
}
