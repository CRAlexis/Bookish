using System;
using System.Collections.Generic;
using Bookish.Models.Database;
using Bookish.Models.View;
using Dapper;
using Npgsql;

namespace Bookish.Services
{
    public interface IBooksService
    {
        IEnumerable<Book> GetAll();
        IEnumerable<BookViewModel> GetLibraryData();

    }

    public class BooksService : IBooksService
    {
        private const string ConnectionString =
            "Server=localhost;Port=5432;Database=bookish;Username=postgres;Password=Mittens.data.biz";

        public IEnumerable<Book> GetAll()
        {
            using var connection = new NpgsqlConnection(ConnectionString);
            return connection.Query<Book>($"SELECT * FROM books");
        }

        public IEnumerable<BookViewModel> GetLibraryData()
        {
            using var connection = new NpgsqlConnection(ConnectionString);
            return connection.Query<BookViewModel>(
                "SELECT genres.genre, books.title, books.year_published, authors.author, books.image FROM genres " +
                "INNER JOIN books on genres.id = books.genre_id " +
                "INNER JOIN authors on authors.id = books.author_id;");
        }
    }
}
