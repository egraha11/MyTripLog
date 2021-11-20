using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyTripLog.Models
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options):base(options)
        {
        }


        public DbSet<Trip> Trips { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }

        public DbSet<TripActivity> TripActivities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Trip>().HasOne(t => t.Destination).WithMany(d => d.Trips).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trip>().HasOne(t => t.Accommodation).WithMany(d => d.Trips).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<TripActivity>().HasKey(ta => new { ta.TripId, ta.ActivityId});

            modelBuilder.Entity<TripActivity>().HasOne(ta => ta.Trip).WithMany(t => t.TripActivities).HasForeignKey(ta => ta.TripId);

            modelBuilder.Entity<TripActivity>().HasOne(ta => ta.Activity).WithMany(a => a.TripActivities).HasForeignKey(ta => ta.ActivityId);
        }
    }
}
