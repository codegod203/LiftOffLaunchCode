using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moonwalkers.Migrations
{
    public partial class mig69 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Suppliers_InventorySupplierId",
                table: "Inventories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "InventorySupplier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventorySupplier",
                table: "InventorySupplier",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_InventorySupplier_InventorySupplierId",
                table: "Inventories",
                column: "InventorySupplierId",
                principalTable: "InventorySupplier",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_InventorySupplier_InventorySupplierId",
                table: "Inventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventorySupplier",
                table: "InventorySupplier");

            migrationBuilder.RenameTable(
                name: "InventorySupplier",
                newName: "Suppliers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Supplier = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Suppliers_InventorySupplierId",
                table: "Inventories",
                column: "InventorySupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }
    }
}
