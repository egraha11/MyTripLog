using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyTripLog.Models
{
    public class Trip
    {

        public int TripId { get; set; }

        [Required(ErrorMessage = "Please enter a destination")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "Please enter a valid start date, ex(xx/xx/xxxx)")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please enter a valid end date, ex(xx/xx/xxxx)")]
        public DateTime EndDate { get; set; }

        public string Accommodation { get; set; }

        public string AccommodationPhone { get; set; }

        public string AccommodationEmail { get; set; }

        public string ThingToDo1 { get; set; }
        public string ThingToDo2 { get; set; }
        public string ThingToDo3 { get; set; }
    }
}
