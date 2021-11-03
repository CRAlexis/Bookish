using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookish.Models.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bookish
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            GenerateDummyData();
                host.Run();
        }

        private static void GenerateDummyData()
        {
            var authors = new Author().GetAll();
            if (!authors.Any())
            {
                new Author().GenerateDummyData();
                new Genre().GenerateDummyData();
                new Member().GenerateDummyData();
                new Book().GenerateDummyData();
                new Copy().GenerateDummyData();
                new Borrowed().GenerateDummyData();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
