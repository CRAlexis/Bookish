using System;
using System.Threading.Channels;
using Bookish.Models.Database;
using Bookish.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Bookish.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        
        private readonly IBooksService _booksService;

        public BookController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        // GET
        public string Index()
        {
            var books = _booksService.GetLibraryData();

            foreach (var book in books)
            {
                Console.WriteLine(book.title);
                Console.WriteLine(book.author);
                Console.WriteLine(book.genre);
            }
            return "View";
        }
    }
}