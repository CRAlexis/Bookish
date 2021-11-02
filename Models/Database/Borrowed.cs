using System;
using Bookish.Models.Repository;
using Npgsql;

namespace Bookish.Models.Database
{
    public class Borrowed
    {
        private readonly NpgsqlConnection _Connection;

        public Borrowed()
        {
            _Connection = Database.Connect();
        }
        
        public int id { get; set; }
        public int copy_id { get; set; }
        public int members_id { get; set; }
        public DateTime checked_out { get; set; }
        public DateTime returned { get; set; }
        public DateTime due_date { get; set; }
        
        public void GenerateDummyData()
        {
            Random rnd = new Random();
            _Connection.Open();

            for (int i = 0; i < 30; i++)
            {
                var cmd = _Connection.CreateCommand();
                var date = RandomData.RandomDate();
                
                cmd.CommandText = $"INSERT INTO borrowed (copy_id, members_id, checked_out, returned, due_date)" +
                                  $"VALUES (@copy_id, @members_id, @checked_out, @returned, @due_date)";
                cmd.Parameters.AddWithValue("copy_id", rnd.Next(1,60));
                cmd.Parameters.AddWithValue("members_id", rnd.Next(1,30));
                cmd.Parameters.AddWithValue("checked_out", date);
                cmd.Parameters.AddWithValue("returned", 
                        date.AddDays(rnd.Next(20,40)) 
                        );
                cmd.Parameters.AddWithValue("due_date", 
                         date.AddDays(30)) 
                        ;
                cmd.ExecuteNonQuery();
            }
            _Connection.Close();
        }

    }
}