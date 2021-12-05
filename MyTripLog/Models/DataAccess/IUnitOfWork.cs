using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTripLog.Models
{
    public interface IUnitOfWork
    {

        Repository<Trip> Trips { get; }
        Repository<Destination> Destinations { get; }
        Repository<Accommodation> Accommodations { get; }
        Repository<Activity> Activities { get; }

        void Save();
    }
}
