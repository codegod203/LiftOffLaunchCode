
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moonwalkers.Data;
using Moonwalkers.Models;
using Moonwalkers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Moonwalkers.Controllers
{
	public class InventorySupplierController : Controller
	{
		private InventoryDbContext context;

        public InventorySupplier theSupplier { get; private set; }

        public InventorySupplierController(InventoryDbContext dbContext)
		{
			context = dbContext;
		}

		// GET: /<controller>/
		[HttpGet]
		public IActionResult Index()
		{
			List<InventorySupplier> suppliers = context.Suppliers.ToList();

			return View(suppliers);
		}
        [HttpGet]
        public IActionResult Create()
        {
			var viewModel = new AddInventorySupplierViewModel();


            return View(viewModel);
        }

        [HttpPost]
		public IActionResult ProcessCreateInventorySupplierForm(AddInventorySupplierViewModel addInventorySupplierViewModel)
		{
			if (ModelState.IsValid)
			{
                InventorySupplier theSupplier = new InventorySupplier
				{
					Supplier = addInventorySupplierViewModel.Supplier
                };

				context.Suppliers.Add(theSupplier);
				context.SaveChanges();

				return Redirect("/InventorySupplier");
			}
			return View("Create", addInventorySupplierViewModel);
		}

		public IActionResult Delete()
		{
			ViewBag.Categories = context.Categories.ToList();
			return View();
		}

		[HttpPost]
		public IActionResult Delete(int[] SupplierIds)
		{
			foreach (int SupplierId in SupplierIds)
			{
				InventorySupplier theSupplier = context.Suppliers.Find(SupplierId);
				context.Suppliers.Remove(theSupplier);
			}

			context.SaveChanges();
			return Redirect("/InventorySupplier");
		}

		
	}
}


