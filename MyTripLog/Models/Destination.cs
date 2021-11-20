using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyTripLog.Models
{
    public class Destination
    {

        public int DestinationId { get; set; }


        [Required(ErrorMessage = "Please enter a destination")]
        public string DestinationName { get; set; }


        public ICollection<Trip> Trips { get; set; }
    }
}
