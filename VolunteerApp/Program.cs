using Microsoft.AspNetCore;
using System;
using System.Data.SqlClient;
using VolunteerApp.Data;

namespace VolunteerApp
{
    class Program
    {
        //static void Main(string[] args)
        //{
            //string connectionString = "Data Source=myServerAddress;Initial Catalog=myDataBase;User ID=myUsername;Password=myPassword;";
            //string connectionString = "Data Source=DESKTOP-JFOOLKD\\SQLEXPRESS;Initial Catalog=VolunteerApp;Integrated Security=True";

            //string sql = "SELECT * FROM Categories";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlCommand command = new SqlCommand(sql, connection);
            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
            //    }
            //    reader.Close();
            //}
            //VolunteerContext myDb = new VolunteerContext();
        //}
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

