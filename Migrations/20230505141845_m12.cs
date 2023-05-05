using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moonwalkers.Migrations
{
    public partial class m12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "InventoryQuantity",
                table: "Inventories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductSellPrice",
                table: "Inventories",
                type: "decimal(65,30)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventoryQuantity",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ProductSellPrice",
                table: "Inventories");

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Inventories",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
