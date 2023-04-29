
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moonwalkers.Data;
using Moonwalkers.Models;
using Microsoft.AspNetCore.Mvc;
using Moonwalkers.ViewModels;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Moonwalkers.Controllers
{
    public class InventoryController : Controller
    {
        private InventoryDbContext context;

        public InventoryController(InventoryDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Inventory> inventories= context.Inventories.ToList();

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

                return Redirect("/Inventories");
            }

            return View(addInventoryViewModel);
        }

        private IActionResult View(object addInventoriesViewModel)
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete()
        {
            ViewBag.inventories= context.Inventories.ToList();

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

            return Redirect("/Inventories");
        }
    }
}