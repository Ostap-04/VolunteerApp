using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volunteer.DataAccess.Annotation;
using Volunteer.Dto.Models;

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
                new Category_RequestAnnotation(modelBuilder)
            };
            foreach (var annotation in annotationCollection)
            {
                annotation.Annotate();
            }
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateFields();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateFields()
        {
            foreach (var entry in ChangeTracker.Entries<IEntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.CreatedBy = "";
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.UtcNow;
                        entry.Entity.ModifiedBy = "";
                        break;
                }
            }
        }

        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Guest> Guest { get; set; }
        public DbSet<Request> Request { get; set; }
        
    }
}
