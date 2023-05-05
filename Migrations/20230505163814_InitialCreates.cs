using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moonwalkers.Migrations
{
    public partial class InitialCreates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "Supplier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Supplier",
                table: "Categories",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Inventories",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
