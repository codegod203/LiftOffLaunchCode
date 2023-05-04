using Microsoft.Extensions.Logging;
using System;
namespace Moonwalkers.Models
{
	public class InventorySupplier
	{

		public int Id { get; set; }
		public string? Supplier { get; set; }
		public List<Inventory> Inventory { get; set; }


		public InventorySupplier()
		{
		}

		public InventorySupplier(string supplier)
		{
			Supplier = supplier;
		}

		public static implicit operator string?(InventorySupplier? v)
		{
			throw new NotImplementedException();
		}
	}
}


