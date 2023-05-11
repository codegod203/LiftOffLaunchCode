using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moonwalkers.Migrations
{
    public partial class mig69420 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalInventory",
                table: "Inventories",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalInventory",
                table: "Inventories");
        }
    }
}
