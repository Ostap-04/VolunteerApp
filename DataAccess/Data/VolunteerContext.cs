using Volunteer.Dto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer;
using Volunteer.DataAccess.Annotation;

namespace DataAccess.Data
{
    public class VolunteerContext : DbContext
    {
        private IDbConnection DbConnection { get; }

        private readonly IConfiguration _configuration;

        public VolunteerContext (DbContextOptions<VolunteerContext> options , IConfiguration configuration)
            : base(options)
        {
            this._configuration = configuration;

            DbConnection = new SqlConnection(this._configuration.GetConnectionString("VolunteerDbConnectionString"));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConnection.ToString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var annotationCollection = new List<IEntityAnnotation>
            {
                new UserAnnotation(modelBuilder),
                new RequestAnnotation(modelBuilder),
                new GuestAnnotation(modelBuilder),
                new CategoryAnnotation(modelBuilder),
                new Category_RequestAnnotation(modelBuilder),
            };
            foreach (var annotation in annotationCollection)
            {
                annotation.Annotate();
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Category_Request> Categories_Requests { get; set;}
        
    }

}
