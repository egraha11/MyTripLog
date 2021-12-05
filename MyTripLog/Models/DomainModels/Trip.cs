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

        [Required(ErrorMessage = "Please enter a valid start date, ex(xx/xx/xxxx)")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Please enter a valid end date, ex(xx/xx/xxxx)")]
        public DateTime? EndDate { get; set; }

        [Range(1, 999999999, ErrorMessage = "Please Enter A Destination.")]
        public int DestinationId { get; set; }
        public Destination Destination {get; set;}

        public int? AccommodationId { get; set; }
        public Accommodation Accommodation { get; set; }

        public ICollection<TripActivity> TripActivities { get; set; }

    }
}
