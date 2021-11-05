using System;
using System.Linq;
using Bookish.Models.Database;
using Bookish.Models.View;
using Bookish.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{

    [Route("/library")]
    public class LibraryController : Controller
    {
        private readonly IBooksService _booksService;

        public LibraryController(IBooksService booksService)
        {
            _booksService = booksService;
        }
        

        [HttpGet("")]
        public IActionResult Library()
        {
            var books = _booksService.GetLibraryData();
            var viewModel = new LibraryViewModel
            {
                Library = books
            };
            return View(viewModel);
        }
        
        
        [HttpGet("{id}")]
        public IActionResult LibraryBook(int id)
        {
            var book = _booksService.GetById(id);
            var viewModel = new LibraryViewModel
            {
                Library = book
            };
            return View(viewModel);
        }
        
        [HttpGet("create")]
        public IActionResult CreateLibraryBookPage()
        {
            return View();
        }
        
        
        [HttpPost("create")]

        public IActionResult CreateBook(Book newBook)

        {
            _booksService.CreateBook(newBook);

            return RedirectToAction("Library");
        }
        
        [HttpGet("update/{id}")]
        public IActionResult UpdateLibraryBookPage(int id, string title, int author_id, int genre_id, int year_published, string image)
        {
            return View();
        }
        
        [HttpPost("update")]

        public IActionResult EditBook(Book newBook)

        {
            _booksService.UpdateBook(newBook);

            return RedirectToAction("Library");
        }
        
    }
}
