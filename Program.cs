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

        public static void GenerateDummyData()
        {
            var authors = new Authors().GetAll();
            if (!authors.Any())
            {
                new Authors().GenerateDummyData();
                new Genres().GenerateDummyData();
                new Members().GenerateDummyData();
                new Books().GenerateDummyData();
                new Copies().GenerateDummyData();
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
