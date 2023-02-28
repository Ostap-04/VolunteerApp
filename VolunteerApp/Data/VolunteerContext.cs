using VolunteerApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace VolunteerApp.Data
{
    public class VolunteerContext : DbContext
    {
        private IDbConnection DbConnection { get; }

        private readonly IConfiguration _configuration;
        public VolunteerContext (DbContextOptions<VolunteerContext> options , IConfiguration configuration)
            : base(options)
        {
            this._configuration = configuration;
            DbConnection = new SqlConnection(this._configuration.GetConnectionString("DefaultConnection"));
            //Database.EnsureCreated();
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
            modelBuilder.Entity<Category_Request>().HasKey(cm => new
            {
                cm.CategoryId,
                cm.RequestId
            });
            modelBuilder.Entity<Category_Request>().HasOne(c => c.Category).WithMany(cm => cm.Category_Requests).HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Category_Request>().HasOne(r => r.Request).WithMany(cm => cm.Category_Requests).HasForeignKey(r => r.RequestId);

            modelBuilder.Entity<Request>().Property(g => g.Goal).HasColumnType("decimal(18,4)");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Category_Request> Categories_Requests { get; set;}
        
    }

}
