using System;
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
        public int book_id { get; set; }
        public string title { get; set; }
        public int year_published { get; set; }
        public bool currently_out { get; set; }
        public int members_id { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public string image { get; set; }
        
        public IEnumerable<Inventory> GetAll()
        {
            var inventory = _Connection.Query<Inventory>(
                $"SELECT " +
                $"genres.genre, " +
                $"books.title, " +
                $"books.image, " +
                $"books.year_published, " +
                $"authors.author, " +
                $"copies.id AS copy_id, " +
                $"books.id AS book_id, " +
                $"(recently_borrowed.checked_out IS NOT NULL AND recently_borrowed.returned IS NULL) AS currently_out, " +
                $"recently_borrowed.members_id " +
                $"FROM genres " +
                $"INNER JOIN books on genres.id = books.genre_id " +
                $"INNER JOIN authors on authors.id = books.author_id " +
                $"INNER JOIN copies on copies.book_id = books.id " +
                $"LEFT JOIN (SELECT DISTINCT ON (copy_id) * from borrowed " +
                $"ORDER BY copy_id, checked_out DESC) " +
                $"recently_borrowed on recently_borrowed.copy_id = copies.id " +
                $"Order by books.title;");
            return inventory;
        }

        public string ToJSON()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                copy_id,
                book_id,
                title,
                year_published,
                currently_out,
                members_id,
                author,
                genre,
                image
            });
        }
    }
}