using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Moonwalkers.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Moonwalkers.ViewModels
{
	public class AddInventoryViewModel
	{

        [Required(ErrorMessage = "Product is required.")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Product must be between 3 and 50 characters.")]
		public string? Product { get; set; }

		[Required(ErrorMessage = "Please enter a description for your product.")]
		[StringLength(500, ErrorMessage = "Description is too long!")]
		public string? Description { get; set; }

		[Required(ErrorMessage = "Quantity is required.")]
		[Display(Name = "Inventory Quantity")]
		public int InventoryQuantity { get; set; }
        [Display(Name = "Inventory Quantity")]
        public int TotalInventory { get; set; }

        [Required(ErrorMessage = "Cost price is required.")]
		[Display(Name = "Product Cost")]
		public decimal? ProductCost { get; set; }



		[Required(ErrorMessage = "Sell price is required.")]
		[Display(Name = "Product Sell Price")]
		public decimal? ProductSellPrice { get; set; }

		[Display(Name = "Transaction ID")]
		public string? TransactionId { get; set; }
		public string? Supplier { get; set; }

		public int? SupplierId { get; set; }
		public int? Id {get; set; }


        public List<SelectListItem> Suppliers { get; set; } = new List<SelectListItem>();

		public AddInventoryViewModel(List<InventorySupplier> suppliers)
		{
			foreach (var supplier in suppliers)
			{
				Suppliers.Add(new SelectListItem
				{
					Value = supplier.Id.ToString(),
					Text = supplier.Supplier
				});
			}
		}

		public AddInventoryViewModel()
		{

		}
	}
}
