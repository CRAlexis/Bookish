using System;
using System.Collections.Generic;
using Dapper;
using Npgsql;

namespace Bookish.Models.Database
{
    public class Books
    {

        private readonly NpgsqlConnection _Connection;

        public Books()
        {
            _Connection = Database.Connect();
        }
        public int id { get; set; }
        public string title { get; set; }
        public int author_id { get; set; }
        public int genre_id { get; set; }
        public int year_published { get; set; }
        public string image { get; set; }

        public IEnumerable<Books> GetAll()
        {
            var books = _Connection.Query<Books>($"SELECT * FROM books");
            _Connection.Close();
            return books;
        }

        public Books GetOne(int bookId)
        {
            var book = _Connection.QuerySingle<Books>($"SELECT * FROM books WHERE id = {bookId}");
            _Connection.Close();
            return book;
        }
    }
}