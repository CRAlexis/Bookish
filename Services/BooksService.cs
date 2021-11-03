using System.Collections.Generic;
using Bookish.Models.Database;
using Dapper;
using Npgsql;

namespace Bookish.Services
{
    public interface IBooksService
    {
        IEnumerable<Book> GetAll();
    }

    public class BooksService : IBooksService
    {
        private const string ConnectionString = "Server=localhost;Port=5432;Database=bookish;Username=postgres;Password=bookish";

        public IEnumerable<Book> GetAll()
        {
            using var connection = new NpgsqlConnection(ConnectionString);
            return connection.Query<Book>("SELECT * FROM books");
        }
    }
}