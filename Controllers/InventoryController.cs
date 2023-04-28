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

namespace CodingEvents.Controllers
{
    public class Inventorycontroller : Controller
    {
        private InventoryDbContext context;

        public InventoryController(InventoryDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Inventory> inventorys= context.Inventories.ToList();

            return View(inventorys);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddInventoryViewModel addEventViewModel = new AddInventoryViewModel();

            return View(addEventViewModel);
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

                return Redirect("/Events");
            }

            return View(addInventoriesViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.events = context.Inventories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                Inventory? theEvent = context.Inventories.Find(eventId);
                context.Inventories.Remove(theInventory);
            }

            context.SaveChanges();

            return Redirect("/Inventories");
        }
    }
}