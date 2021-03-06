using System;
using System.Collections.Generic;
using Bookish.Models.Repository;
using Dapper;
using Npgsql;

namespace Bookish.Models.Database
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public int author_id { get; set; }
        public int genre_id { get; set; }
        public int year_published { get; set; }
        public string image { get; set; }
        
        
        // public void GenerateDummyData()
        // {
        //     Random rnd = new Random();
        //     _Connection.Open();
        //
        //     for (int i = 0; i < 30; i++)
        //     {
        //         var cmd = _Connection.CreateCommand();
        //         
        //         cmd.CommandText = $"INSERT INTO books (title, author_id, genre_id, year_published, image)" +
        //                           $"VALUES (@title, @author_id, @genre_id, @year, @image)";
        //         cmd.Parameters.AddWithValue("title", RandomData.titles[i]);
        //         cmd.Parameters.AddWithValue("author_id", rnd.Next(1, 30));
        //         cmd.Parameters.AddWithValue("genre_id", rnd.Next(1, 30));
        //         cmd.Parameters.AddWithValue("year", rnd.Next(1500, 2020));
        //         cmd.Parameters.AddWithValue("image", "https://picsum.photos/1600/900");
        //         cmd.ExecuteNonQuery();
        //     }
        //     _Connection.Close();
        // }
    }
}