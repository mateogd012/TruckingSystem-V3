using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckingSystem_V3.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TripStatus",
                table: "Trips");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TripStatus",
                table: "Trips",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
