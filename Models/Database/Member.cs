using System;
using System.Collections.Generic;
using System.Linq;
using Bookish.Models.Repository;
using Dapper;
using Npgsql;

namespace Bookish.Models.Database
{
    public class Member
    {
        private readonly NpgsqlConnection _Connection;

        public Member()
        {
            _Connection = Database.Connect();
        }
        
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public List<Member> GetAll()
        {
            var members = _Connection.Query<Member>(
                $"SELECT * FROM members;");
            return members.ToList();
        }

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