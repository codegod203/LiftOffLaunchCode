using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moonwalkers.Data;
using Moonwalkers.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Moonwalkers.Controllers
{
    public class SearchController : Controller
    {
        private readonly InventoryDbContext _context;

        public SearchController(InventoryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchString)
        {
            var inventory = from i in _context.Inventories
                            select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                inventory = inventory.Where(s => s.Product.Contains(searchString));
            }

            return View(await inventory.ToListAsync());
        }
    }
}
