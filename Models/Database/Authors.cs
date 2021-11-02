using System;
using System.Collections.Generic;
using System.Data;
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
    }

}