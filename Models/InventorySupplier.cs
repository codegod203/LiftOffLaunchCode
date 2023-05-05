using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Moonwalkers.Models
{
    public class InventorySupplier
    {
        public int Id { get; set; }
        public string? Supplier { get; set; }
        public List<Inventory>? Inventory { get; set; }

        public InventorySupplier()
        {
            Inventory = new List<Inventory>();
        }

        public InventorySupplier(string supplier) : this()
        {
            Supplier = supplier;
        }
    }
}
