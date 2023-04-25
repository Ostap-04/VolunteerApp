using FirebaseAdmin.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        public override int SaveChanges()
        {
            UpdateFields();
            return base.SaveChanges();
        }

        private void UpdateFields()
        {
            var user = new User();
            if (user != null)
            {
                var modifiedEntities = ChangeTracker.Entries()
                            .Where(p => p.State == EntityState.Modified || p.State == EntityState.Added || p.State == EntityState.Deleted || p.State == EntityState.Modified || p.State == EntityState.Detached).ToList();
                foreach (var entry in modifiedEntities)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            user.CreatedDate = DateTime.UtcNow;
                            user.CreatedBy = user.Id;
                            break;
                        case EntityState.Modified:
                            user.ModifiedDate = DateTime.UtcNow;
                            user.ModifiedBy = user.Id;
                            break;
                    }
                }
            }
        }

        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Guest> Guest { get; set; }
        public DbSet<Request> Request { get; set; }
        
    }
}
