using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyTripLog.Models
{
    public class TripActivityConfig : IEntityTypeConfiguration<TripActivity>
    {

        public void Configure(EntityTypeBuilder<TripActivity> entity)
        {
            entity.HasKey(ta => new { ta.TripId, ta.ActivityId });

            entity.HasOne(ta => ta.Trip).WithMany(t => t.TripActivities).HasForeignKey(ta => ta.TripId);

            entity.HasOne(ta => ta.Activity).WithMany(a => a.TripActivities).HasForeignKey(ta => ta.ActivityId);
        }
    }
}
