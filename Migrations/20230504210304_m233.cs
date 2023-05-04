using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moonwalkers.Migrations
{
    public partial class m233 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Inventories");

            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "Inventories",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "Inventories",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
