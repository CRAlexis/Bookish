using System.Collections.Generic;
using System.Linq;
using Dapper;
using Npgsql;

namespace Bookish.Models.Database
{
    public class Inventory
    {
        private readonly NpgsqlConnection _Connection;

        public Inventory()
        {
            _Connection = Database.Connect();
        }
        public int copy_id { get; set; }
        public string title { get; set; }
        public int year_published { get; set; }
        public string checked_out { get; set; }
        public string author { get; set; }
        public string genre { get; set; }

        public IEnumerable<Inventory> GetAll()
        {
            var inventory = _Connection.Query<Inventory>(
                $"SELECT genres.genre, books.title, books.year_published, authors.author, copies.id AS copy_id " +
                $"FROM genres " +
                $"INNER JOIN books on genres.id = books.genre_id " +
                $"INNER JOIN authors on authors.id = books.author_id " +
                $"INNER JOIN copies on copies.book_id = books.id " +
                $"Order by books.title;");
            _Connection.Close();
            return inventory;
        }
    }
}