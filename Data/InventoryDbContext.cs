using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moonwalkers.Models;
using QRCoder;
using Microsoft.Extensions.Logging;

namespace Moonwalkers.Data
{
    public class InventoryDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventorySupplier> Categories { get; set; }
        public DbSet<InventorySupplier> Suppliers { get; set; }
        public DbSet<EventModel> Events { get; set; } // New DbSet for events

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // Additional methods and configurations as needed
    }
}
