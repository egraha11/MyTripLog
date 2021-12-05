using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyTripLog.Models
{
    public class TripConfig : IEntityTypeConfiguration<Trip>
    {

        public void Configure(EntityTypeBuilder<Trip> entity)
        {
            entity.HasOne(t => t.Destination).WithMany(d => d.Trips).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(t => t.Accommodation).WithMany(a => a.Trips).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
