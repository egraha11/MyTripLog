using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTripLog.Models
{
    public class ManageViewModel : DropDownViewModel
    {

        public Destination Destination { get; set; }
        public Accommodation Accommodation { get; set; }
        public Activity Activity { get; set; }

    }
}
