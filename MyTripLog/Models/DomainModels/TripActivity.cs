using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTripLog.Models
{
    public class TripActivity
    {

        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }


    }
}
