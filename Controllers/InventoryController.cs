using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moonwalkers.Data;
using Moonwalkers.Models;
using Microsoft.AspNetCore.Mvc;
using Moonwalkers.ViewModels;
using Microsoft.Extensions.Logging;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Moonwalkers.Controllers
{
    public class InventoryController : Controller
    {
        private InventoryDbContext context;

        public InventoryController(InventoryDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Inventory> inventories = context.Inventories.ToList();
            //   List<Inventory> inventories = context.Inventories.Include(e => e.Supplier).ToList();
            return View(inventories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddInventoryViewModel addInventoryViewModel = new AddInventoryViewModel();
            addInventoryViewModel.Suppliers = context.Suppliers
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Supplier
                })
                .ToList();
            return View(addInventoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddInventoryViewModel addInventoryViewModel)
        {
            if (ModelState.IsValid)
            {
                string? transactionId = Guid.NewGuid().ToString(); // Generate a unique transaction ID
                Inventory newInventory = new Inventory
                {
                    Product = addInventoryViewModel.Product,
                    Description = addInventoryViewModel.Description,
                    Supplier = addInventoryViewModel.Supplier,
                    ProductCost = addInventoryViewModel.ProductCost,
                    ProductSellPrice = addInventoryViewModel.ProductSellPrice,
                    InventoryQuantity = addInventoryViewModel.InventoryQuantity,
                    TransactionId = transactionId // Set the transaction number to the unique ID
                };
                context.Inventories.Add(newInventory);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addInventoryViewModel);
        }


        public IActionResult Delete()
        {
            ViewBag.Inventories = context.Inventories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] inventoryIds)
        {
            foreach (int inventoryId in inventoryIds)
            {
                Inventory? theInventory = context.Inventories.Find(inventoryId);
                context.Inventories.Remove(theInventory);
            }
            context.SaveChanges();
            return Redirect("/Home");
        }

        public IActionResult View(int id)
        {
            Inventory inventory = context.Inventories.Single(i => i.Id == id);
            return View(inventory);
        }
    }
}
