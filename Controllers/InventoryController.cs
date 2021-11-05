using System;
using System.Linq;
using Bookish.Models.Database;
using Bookish.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{
    public class InventoryController : Controller
    {
        // GET
        public IActionResult Index(string bookTitle = "", int bookId = 0)
        {
            var inventory = new Inventory().GetAll();
            var members = new Member().GetAll();

            return View(new InventoryViewModel
            {
                Inventory = inventory.ToList(),
                BookTitle = bookTitle,
                Members = members,
                BookId = bookId
            });
        }

        [HttpPost("/checkout")]
        public IActionResult CheckOut(int memberId, int copyId, bool checkingOut)
        {
            Console.WriteLine("checking out " + checkingOut);
            Console.WriteLine("copy id " + copyId);
            Console.WriteLine("memberId " + memberId);
            Console.WriteLine();
            if (checkingOut)
            {
                new Borrowed().CheckOut(copyId, memberId);
            }
            else
            {
                new Borrowed().CheckIn(copyId, memberId);
            }
            
            var inventory = new Inventory().GetAll();
            var members = new Member().GetAll();

            return View("~/Views/Inventory/Index.cshtml",new InventoryViewModel
            {
                Inventory = inventory.ToList(),
                BookTitle = "",
                Members = members,
                BookId = 0
            });
        }
    }
}