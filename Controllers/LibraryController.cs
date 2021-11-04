﻿using System;
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
    }
}
