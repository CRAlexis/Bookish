﻿using System;
using Bookish.Models.Repository;
using Npgsql;

namespace Bookish.Models.Database
{
    public class Members
    {
        private readonly NpgsqlConnection _Connection;

        public Members()
        {
            _Connection = Database.Connect();
        }
        
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        
        public void GenerateDummyData()
        {
            Random rnd = new Random();
            _Connection.Open();

            for (int i = 0; i < 30; i++)
            {
                var cmd = _Connection.CreateCommand();
                
                cmd.CommandText = $"INSERT INTO members (name, email) VALUES (@name, @email)";
                cmd.Parameters.AddWithValue("name", RandomData.names[rnd.Next(0,98)]);
                cmd.Parameters.AddWithValue("email",
                    $"{RandomData.names[rnd.Next(0,98)].Replace(" ", "_")}{i}@email.com");
                cmd.ExecuteNonQuery();
            }
            _Connection.Close();
        }
    }
}