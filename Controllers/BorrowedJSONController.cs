using System.Collections.Generic;
using System.Linq;
using Bookish.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{
    public class BorrowedJSONController : Controller
    {
        // GET One
        [HttpGet("borrowed-json/{bookId}")]

        public List<string> Index(int bookId)
        {
            var res = new Borrowed().GetOneAsJson(bookId);
            return res;
        }
    }
}