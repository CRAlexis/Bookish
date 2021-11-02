using System;
using Bookish.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        // GET
        public string Index()
        {
            var authors = new Authors().GetAll();

            foreach (var author in authors)
            {
                Console.WriteLine(author.author);
            }
            return "View";
        }
    }
}