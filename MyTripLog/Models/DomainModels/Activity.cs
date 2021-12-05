using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTripLog.Models
{
    public class Activity
    {

        public int ActivityId { get; set; }
        public string Name { get; set; }

        public ICollection<TripActivity> TripActivities { get; set; }
    }
}
