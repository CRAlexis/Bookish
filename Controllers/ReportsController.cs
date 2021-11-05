using Bookish.Models.Database;
using Bookish.Models.View;
using Bookish.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{

    [Route("/reports")]
    public class ReportsController : Controller
    {
        private readonly IBooksService _booksService;

        public ReportsController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet("/reports")]
        public IActionResult Reports()
        {
            return View();
        }

        [HttpGet("/reports/authors")]
        public IActionResult Authors()
        {
            var authors = _booksService.GetAuthors();
            var viewModel = new AuthorsViewModel
            {
                Authors = authors
            };
            return View(viewModel);

        }
        
        [HttpGet("/reports/genres")]
        public IActionResult Genres()
        {
            var genres = _booksService.GetGenres();
            var viewModel = new GenresViewModel
            {
                Genres = genres
            };
            return View(viewModel);

        }
    }
    
    }