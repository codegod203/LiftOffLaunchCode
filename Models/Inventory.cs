﻿using System;
namespace Moonwalkers.Models
{
	public class Inventory
	{
		public string? Product { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public string? Supplier { get; set; }
		public string? ContactEmail { get; set; }
		//	public InventoryType Type { get; set; }

		public int Id { get; set; }

		public Inventory()
		{
		}

		public Inventory(string name, string product, string description, string contactEmail, string supplier)
		{
			Name = Name;
			Product = product;
			Description = description;
			Supplier = supplier;
			ContactEmail = contactEmail;
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