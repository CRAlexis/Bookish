using System;
using Bookish.Models.Repository;
using Npgsql;

namespace Bookish.Models.Database
{
    public class Copies
    {
        private readonly NpgsqlConnection _Connection;

        public Copies()
        {
            _Connection = Database.Connect();
        }
        public int id { get; set; }
        public int book_id { get; set; }
        
        public void GenerateDummyData()
        {
            Random rnd = new Random();
            _Connection.Open();

            for (int i = 0; i < 60; i++)
            {
                var cmd = _Connection.CreateCommand();
                
                cmd.CommandText = $"INSERT INTO copies (book_id) VALUES (@book_id)";
                cmd.Parameters.AddWithValue("book_id", rnd.Next(1, 30));
                cmd.ExecuteNonQuery();
            }
            _Connection.Close();
        }
    }
}