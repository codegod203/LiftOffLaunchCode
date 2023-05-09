using System;

namespace Moonwalkers.Models
{
    public class Inventory  

    {

        private int inventoryQuantity;

        public string? Product { get; set; }
        public string? Description { get; set; }
        public string? Supplier { get; set; }
        public decimal? ProductCost { get; set; }
        public decimal? ProductSellPrice { get; set; }
        public int? InventoryQuantity { get; set; }
        public string? TransactionId { get; set; }
        public int? TotalInventory { get; set; }

        public int? Id { get; set; }

        public string? QRCode { get; set; } // Added property

        public Inventory()
        {
        }

        public Inventory(string product, string description, string supplier, decimal productCost, decimal productSellPrice, int inventoryQuantity, int totalInventory, string transactionId)
        {
            Product = product;
            Description = description;
            Supplier = supplier;
            ProductCost = productCost;
            ProductSellPrice = productSellPrice;
            InventoryQuantity = inventoryQuantity;
            TotalInventory = totalInventory;
            TransactionId = transactionId;
        }

        public override string? ToString()
        {
            return Supplier;
        }

        public override bool Equals(object? obj)
        {
            return obj is Inventory @inventory && Id == @inventory.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public decimal? GetFormattedProductCost()
        {
            return ProductCost != null ? decimal.Round(ProductCost.Value, 2) : (decimal?)null;
        }

        public decimal? GetFormattedProductSellPrice()
        {
            return ProductSellPrice != null ? decimal.Round(ProductSellPrice.Value, 2) : (decimal?)null;
        }
    }
}
