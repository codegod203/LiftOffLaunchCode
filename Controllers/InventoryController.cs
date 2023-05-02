using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moonwalkers.Data;
using Moonwalkers.Models;
using Microsoft.AspNetCore.Mvc;
using Moonwalkers.ViewModels;
using Microsoft.Extensions.Logging;

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
            return View(inventories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddInventoryViewModel addInventoryViewModel = new AddInventoryViewModel();
            return View(addInventoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddInventoryViewModel addInventoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Inventory newInventory = new Inventory
                {
                    Name = addInventoryViewModel.Name,
                    Description = addInventoryViewModel.Description,
                    ContactEmail = addInventoryViewModel.ContactEmail,
                    Type = addInventoryViewModel.Type
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
                Inventory theInventory = context.Inventories.Find(inventoryId);
                context.Inventories.Remove(theInventory);
            }

            context.SaveChanges();
            return RedirectToAction("/Index");
        }

        public IActionResult View(int id)
        {
            Inventory inventory = context.Inventories.Single(i => i.Id == id);
            return View(inventory);
        }
    }
}
