using Moonwalkers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Moonwalkers.Data
{
    public class InventoryDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        internal object inventories;

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryCategory> Categories { get; set; }
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }
        
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

        }
    }
}