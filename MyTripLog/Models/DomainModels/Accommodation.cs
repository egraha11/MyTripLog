using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTripLog.Models
{
    public class Accommodation
    {

        public int AccommodationId { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public ICollection<Trip> Trips { get; set; }
    }
}
