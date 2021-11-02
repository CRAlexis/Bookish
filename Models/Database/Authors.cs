using System;
using System.Collections.Generic;
using System.Data;
using Bookish.Models.Repository;
using Dapper;
using Npgsql;

namespace Bookish.Models.Database
{
    public class Authors
    {
        private readonly NpgsqlConnection _Connection;

        public Authors()
        {
            _Connection = Database.Connect();
        }
        
        public int id { get; set; }
        public string author { get; set; }
    
        public IEnumerable<Authors> GetAll()
        {
            var authors = _Connection.Query<Authors>($"SELECT * FROM authors");
            _Connection.Close();
            return authors;
        }

        public Authors GetOne(int authorId)
        {
            var author = _Connection.QuerySingle<Authors>($"SELECT * FROM authors WHERE id = {authorId}");
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