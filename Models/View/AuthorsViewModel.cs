using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookish.Models.View
{
    public class AuthorsViewModel
    {
        public IEnumerable<AuthorViewModel> Authors { get; set; }
    }
}