using System;
namespace Moonwalkers.Models
{
    public class InventoryCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }


        public InventoryCategory()
        {
        }

        public InventoryCategory(string name)
        {
            Name = name;
        }
    }
}