using System;
using System.Collections.Generic;
using System.Linq;
using Bookish.Models.Repository;
using Dapper;
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
        public DateTime? returned { get; set; }
        public DateTime due_date { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public void CheckOut(int copyId, int memId)
        {
            _Connection.Open();
            var cmd = _Connection.CreateCommand();

            cmd.CommandText = $"INSERT INTO borrowed (copy_id, members_id, checked_out, due_date)" +
                              $"VALUES (@copy_id, @members_id, @checked_out, @due_date)";
            cmd.Parameters.AddWithValue("copy_id", copyId);
            cmd.Parameters.AddWithValue("members_id", memId);
            cmd.Parameters.AddWithValue("checked_out", DateTime.Now);
            cmd.Parameters.AddWithValue("due_date",
                    DateTime.Now.AddDays(30))
                ;
            cmd.ExecuteNonQuery();
            _Connection.Close();
        }
        
        public void CheckIn(int copyId, int memId)
        {
            Console.WriteLine("Checking in");
            Console.WriteLine("copyId " + copyId);
            Console.WriteLine("memId " + memId);
            _Connection.Open();
            var cmd = _Connection.CreateCommand();

            cmd.CommandText = $"UPDATE borrowed SET returned = @returned WHERE copy_id = @copyId AND members_id = @membersId;";
            cmd.Parameters.AddWithValue("copyId", copyId);
            cmd.Parameters.AddWithValue("membersId", memId);
            cmd.Parameters.AddWithValue("returned", DateTime.Now);
            Console.WriteLine(cmd.CommandText);
            var query = cmd.ExecuteNonQuery();

            Console.WriteLine("query: " + query);
            _Connection.Close();
        }

        public List<string> GetOneAsJson(int copyId)
        {
            const string sql =
                "SELECT * FROM borrowed INNER JOIN members on members.id = borrowed.members_id where copy_id = @copyId";

            var dictionary = new Dictionary<string, object>
            {
                {"@copyId", copyId}
            };

            var parameters = new DynamicParameters(dictionary);

            var borrowed = _Connection.Query<Borrowed>(sql, parameters).ToList();
            return ListToJSON(borrowed);
        }

        private List<string> ListToJSON(List<Borrowed> borrowed)
        {
            var res = new List<string>();
            foreach (var b in borrowed)
            {
                res.Add(b.ToJSON());
            }

            return res;
        }

        private string ToJSON()
        {
            //json.net
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                id,
                copy_id,
                members_id,
                checked_out,
                returned,
                due_date,
                name,
                email
            });
        }

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
                cmd.Parameters.AddWithValue("copy_id", rnd.Next(1, 60));
                cmd.Parameters.AddWithValue("members_id", rnd.Next(1, 30));
                cmd.Parameters.AddWithValue("checked_out", date);
                cmd.Parameters.AddWithValue("returned",
                    date.AddDays(rnd.Next(20, 40))
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