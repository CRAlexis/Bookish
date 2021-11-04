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
        IEnumerable<BookViewModel> GetById(int id);
        IEnumerable<BookViewModel> GetLibraryData();

    }

    public class BooksService : IBooksService
    {
        private const string ConnectionString =
            "Server=localhost;Port=5432;Database=bookish;Username=postgres;Password=bookish";

        public IEnumerable<Book> GetAll()
        {
            using var connection = new NpgsqlConnection(ConnectionString);
            return connection.Query<Book>($"SELECT * FROM books");
        }

        public IEnumerable<BookViewModel> GetById(int id)
        {
            using var connection = new NpgsqlConnection(ConnectionString);
            var parameters = new {BookId = id};

            var sql =
                "SELECT genres.genre, books.title, books.year_published, authors.author, books.image, books.id AS book_id FROM genres INNER JOIN books on genres.id = books.genre_id INNER JOIN authors on authors.id = books.author_id WHERE books.id = @BookId;";
            return connection.Query<BookViewModel>(sql, parameters);
        }
        public IEnumerable<BookViewModel> GetLibraryData()
        {
            using var connection = new NpgsqlConnection(ConnectionString);
            return connection.Query<BookViewModel>(
                "SELECT books.id as book_id, authors.id as author_id, genres.genre, books.title, books.year_published, authors.author, books.image FROM genres " +
                "INNER JOIN books on genres.id = books.genre_id " +
                "INNER JOIN authors on authors.id = books.author_id;");
        }
    }
}