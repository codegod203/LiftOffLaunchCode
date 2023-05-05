using System;
namespace Moonwalkers.Models
{
    public class NewInventorySupplier
    {
        public int Id { get; set; }
        public string? Supplier { get; set; }

        public NewInventorySupplier()
        {
        }

        public NewInventorySupplier(string supplier)
        {
            Supplier = supplier;
        }
    }
}
