using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Bookish.Models.Database;
using Bookish.Models.Repository;
using Dapper;
using Npgsql;

namespace Bookish.Models.View
{
    public class LibraryViewModel
    {
        public IEnumerable<BookViewModel> Library { get; set; }
    }
}