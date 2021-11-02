using System;
using Bookish.Models.Repository;
using Npgsql;

namespace Bookish.Models.Database
{
    public class Genres
    {
        private readonly NpgsqlConnection _Connection;

        public Genres()
        {
            _Connection = Database.Connect();
        }
        
        public int id { get; set; }
        public string genre { get; set; }
        
        public void GenerateDummyData()
        {
            Random rnd = new Random();
            _Connection.Open();

            for (int i = 0; i < 30; i++)
            {
                var cmd = _Connection.CreateCommand();
                
                cmd.CommandText = $"INSERT INTO genres (genre) VALUES (@genre)";
                cmd.Parameters.AddWithValue("genre", RandomData.genres[rnd.Next(0,14)]);
                cmd.ExecuteNonQuery();
            }
            _Connection.Close();
        }
    }
}