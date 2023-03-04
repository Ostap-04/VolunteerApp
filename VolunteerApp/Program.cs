using Microsoft.AspNetCore;
using System;
using System.Data.SqlClient;
using DataAccess.Data;

namespace VolunteerApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

