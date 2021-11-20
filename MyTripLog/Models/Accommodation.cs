using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTripLog.Models
{
    public class Accommodation
    {

        public int AccommodationId { get; set; }
        public string AccommodationName { get; set; }

        public string AccommodationPhone { get; set; }

        public string AccommodationEmail { get; set; }

        public ICollection<Trip> Trips { get; set; }
    }
}
