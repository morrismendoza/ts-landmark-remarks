using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Landmark.API.Models
{
    public class LandmarkDataAccess : DbContext
    {
        public LandmarkDataAccess() : base("local-db")
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserLocation> UserLocations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().HasKey(x => new { x.Id });
            modelBuilder.Entity<User>().Property(x => x.LastAccessed).HasColumnName("last_accessed");

            modelBuilder.Entity<UserLocation>().ToTable("user_locations");
            modelBuilder.Entity<UserLocation>().HasKey(x => new { x.Id });
            modelBuilder.Entity<UserLocation>().Property(x => x.DateCreated).HasColumnName("date_created");
            modelBuilder.Entity<UserLocation>().Property(x => x.UserId).HasColumnName("user_id");
        }
    }
}