using System.Drawing.Imaging;
using Moonwalkers.Data;
using Moonwalkers.Models;
using Microsoft.AspNetCore.Mvc;
using Moonwalkers.ViewModels;
using Microsoft.Extensions.Logging;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing.Imaging;
using System.IO;
using QRCoder;
using System.Text;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Microsoft.AspNetCore.Authorization;

namespace Moonwalkers.Controllers
{
    public class InventoryController : Controller

    {
        private InventoryDbContext context;

        public InventoryController(InventoryDbContext dbContext)
        {
            context = dbContext;
        }

        private string GenerateQRCode(Inventory inventory)
        {
            var payload = new StringBuilder();
            payload.AppendLine($"Product: {inventory.Product}");
            payload.AppendLine($"Description: {inventory.Description}");
            payload.AppendLine($"Supplier: {inventory.Supplier}");
            payload.AppendLine($"ProductCost: {inventory.ProductCost}");
            payload.AppendLine($"ProductSellPrice: {inventory.ProductSellPrice}");
            payload.AppendLine($"InventoryQuantity: {inventory.InventoryQuantity}");
            payload.AppendLine($"TransactionId: {inventory.TransactionId}");

            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(payload.ToString(), QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(2);

            var stream = new MemoryStream();
            qrCodeImage.Save(stream, ImageFormat.Png);

            return $"data:image/png;base64,{Convert.ToBase64String(stream.ToArray())}";
        }

        public IActionResult Index()
        {
            List<Inventory> inventories = context.Inventories.ToList();
            //   List<Inventory> inventories = context.Inventories.Include(e => e.Supplier).ToList();
            foreach (Inventory inventory in inventories)

            {
                inventory.QRCode = GenerateQRCode(inventory);
            }
            return View(inventories);
        }
        [Authorize(Roles = "Admin, editor")]
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
                    TotalInventory = addInventoryViewModel.TotalInventory,

                    TransactionId = transactionId // Set the transaction number to the unique ID
                };
                newInventory.QRCode = GenerateQRCode(newInventory);
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
        public IActionResult GenerateQRCode(int id)
        {
            var inventory = context.Inventories.FirstOrDefault(i => i.Id == id);
            if (inventory == null)
            {
                return NotFound();
            }

            var qrCode = GenerateQRCode(inventory);
            byte[] imageBytes = Convert.FromBase64String(qrCode.Replace("data:image/png;base64,", ""));
            return File(imageBytes, "image/png");
        }


        public IActionResult View(int id)
        {
            Inventory inventory = context.Inventories.Single(i => i.Id == id);
            return View(inventory);
        }
    }
}
