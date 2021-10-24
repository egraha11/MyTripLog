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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Trip>().HasData(
            new Trip
            {
                TripId = 1,
                Destination = "New York City",
                Accommodation = "The Ritz",
                StartDate = new DateTime(10/25/2020),
                EndDate = new DateTime(11/1/ 2020),
                AccommodationPhone = "330-330-3330",
                AccommodationEmail = "accomodation@gmail.com",
                ThingToDo1 = "Go to a show",
                ThingToDo2 = "Ride the subway"
            }
            );
        }
    }
}
