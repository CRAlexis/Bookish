using System.Linq;
using Bookish.Models.Database;
using Bookish.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{
    public class InventoryController : Controller
    {
        // GET
        public IActionResult Index(string queryString = "")
        {
            var inventory = new Inventory().GetAll();
            var members = new Member().GetAll();
            
            return View(new InventoryViewModel
            {
                Inventory = inventory.ToList(),
                QueryString = queryString,
                Members = members
            });
        }
    }
}