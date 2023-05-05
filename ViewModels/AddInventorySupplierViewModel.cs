
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Moonwalkers.ViewModels
{
    public class AddInventorySupplierViewModel
    {
        public int? SupplierId { get; set; }
     //   public List<SelectListItem>? Suppliers { get; set; }
        public string? Supplier { get;  set; }
    }
}


