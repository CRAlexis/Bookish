using System;
using System.Collections.Generic;
using System.Data;
using Bookish.Models.Repository;
using Dapper;
using Npgsql;

namespace Bookish.Models.Database
{
    public class Author
    {
        private readonly NpgsqlConnection _Connection;

        public Author()
        {
            _Connection = Database.Connect();
        }
        
        public int id { get; set; }
        public string author { get; set; }
    
        public IEnumerable<Author> GetAll()
        {
            var authors = _Connection.Query<Author>($"SELECT * FROM authors");
            _Connection.Close();
            return authors;
        }

        public Author GetOne(int authorId)
        {
            var author = _Connection.QuerySingle<Author>($"SELECT * FROM authors WHERE id = {authorId}");
            _Connection.Close();
            return author;
        }

        public void GenerateDummyData()
        {
            Random rnd = new Random();
            _Connection.Open();

            for (int i = 0; i < 30; i++)
            {
                var cmd = _Connection.CreateCommand();
                
                cmd.CommandText = $"INSERT INTO authors (author) VALUES (@name)";
                cmd.Parameters.AddWithValue("name", RandomData.names[rnd.Next(0,98)]);
                cmd.ExecuteNonQuery();
            }
                _Connection.Close();
        }
    }
}