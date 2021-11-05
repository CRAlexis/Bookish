using System.Collections.Generic;

namespace Bookish.Models.View
{
    public class GenresViewModel
    {
        public IEnumerable<GenreViewModel> Genres { get; set; }
    }
}