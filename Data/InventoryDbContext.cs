using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moonwalkers.Models;
using QRCoder;

namespace Moonwalkers.Data
{
    public class InventoryDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventorySupplier> Categories { get; set; }
        public DbSet<InventorySupplier> Suppliers { get; set; }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public List<Inventory> GetInventoriesWithTotalInventory()
        {
            using (var context = new InventoryDbContext(new DbContextOptionsBuilder<InventoryDbContext>()
                .UseSqlServer("server=localhost;user=inventorymanagement;password=inventorymanagement;database=inventorymanagement")
                .Options))
            {
                var total = context.Inventories.FromSqlRaw("SELECT  Id,Product, Description,Supplier,ProductCost,ProductSellPrice,TransactionId,QRCode,InventoryQuantity,(SELECT SUM(InventoryQuantity)FROM Inventories as i2 WHERE i2.Product = i1.Product) AS TotalInventory FROM Inventories AS i1").ToList();
                return total;
            }
        }

    }
}
