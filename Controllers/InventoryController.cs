using System.Linq;
using Bookish.Models.Database;
using Bookish.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{
    public class InventoryController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var inventory = new Inventory().GetAll();
            
            return View(new InventoryViewModel
            {
                Inventory = inventory.ToList()
            });
        }
    }
}