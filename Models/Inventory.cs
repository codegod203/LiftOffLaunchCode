using System;

namespace Moonwalkers.Models
{
    public class Inventory
    {
        private int inventoryQuantity;

        public string? Name { get; set; }
        public string? Product { get; set; }
        public string? Description { get; set; }
        public string? Supplier { get; set; }
        public decimal? ProductCost { get; set; }
        public decimal? ProductSellPrice { get; set; }
        public int? InventoryQuantity { get; set; }
        public int? TransactionId { get; set; }
        public int? Id { get; set; }

        public Inventory()
        {
        }

        public Inventory(string name, string product, string description, string supplier, decimal productCost, decimal productSellPrice, int inventoryQuantity, int transactionId)
        {
            Name = name;
            Product = product;
            Description = description;
            Supplier = supplier;
            ProductCost = productCost;
            ProductSellPrice = productSellPrice;
            InventoryQuantity = inventoryQuantity;
            TransactionId = transactionId;
        }

        public override string? ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Inventory @inventory && Id == @inventory.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
