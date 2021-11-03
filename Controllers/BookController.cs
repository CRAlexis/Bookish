using System;
using Bookish.Models.Database;
using Bookish.Services;
using Microsoft.AspNetCore.Mvc;

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
            var books = _booksService.GetAll();

            foreach (var book in books)
            {
                Console.WriteLine(book.title);
            }
            return "View";
        }
    }
}