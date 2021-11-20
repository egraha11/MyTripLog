using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTripLog.Models;

namespace MyTripLog.Controllers
{
    public class TripController : Controller
    {

        TripContext context;

        public IActionResult Index()
        {
            return View();
        }

        public TripController(TripContext cxt)
        {
            context = cxt;
        }


        public IActionResult DeleteDestination(int id)
        {
            Trip deleteTrip = context.Trips.Find(id);
            context.Trips.Remove(deleteTrip);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ViewResult Add()
        {

            ViewBag.Destinations = context.Destinations.OrderBy(d => d.DestinationName).ToList();
            ViewBag.Accommodations = context.Accommodations.OrderBy(d => d.AccommodationName).ToList();

            return View("Page1", new Trip());
        }




        [HttpGet]
        public ViewResult Manage()
        {

            ViewBag.Destinations = context.Destinations.OrderBy(d => d.DestinationName).ToList();
            ViewBag.Accommodations = context.Accommodations.OrderBy(acc => acc.AccommodationName).ToList();
            ViewBag.Activities = context.Activities.OrderBy(act => act.ActivityName).ToList();

            return View("Manage", new TripViewModel());
        }

        [HttpPost]
        public IActionResult Manage(TripViewModel newTripView)
        {

            if(newTripView.DestinationString != null)
            {
                Destination newDest = new Destination();
                newDest.DestinationName = newTripView.DestinationString;
                context.Destinations.Add(newDest);
                context.SaveChanges();

                /**
                Destination dest2 = context.Destinations.Where(d => d.DestinationName == newDest.DestinationName).FirstOrDefault();
                return Content(dest2.DestinationName);
                **/
            }

            if (newTripView.AccommodationStringName != null)
            {
                Accommodation accommodation = new Accommodation();
                accommodation.AccommodationName = newTripView.AccommodationStringName;

                if(newTripView.AccommodationStringPhone != null)
                {
                    accommodation.AccommodationPhone = newTripView.AccommodationStringPhone;
                }
                if(newTripView.AccommodationStringEmail != null)
                {
                    accommodation.AccommodationEmail = newTripView.AccommodationStringEmail;
                }
                context.Accommodations.Add(accommodation);
                context.SaveChanges();
            }
            if (newTripView.ActivityString != null)
            {
                Activity activity = new Activity();

                activity.ActivityName = newTripView.ActivityString;

                context.Activities.Add(activity);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public RedirectToActionResult Delete(int destination = 0, int accommodation = 0, int activity = 0)
        {

            if(destination != 0)
            {
                var dest = context.Destinations.Find(destination);
                context.Destinations.Remove(dest);
                context.SaveChanges();
            }
            if(accommodation != 0)
            {
                var acc = context.Accommodations.Find(accommodation);
                context.Accommodations.Remove(acc);
                context.SaveChanges();
            }
            if (activity != 0)
            {
                var acc = context.Activities.Find(activity);
                context.Activities.Remove(acc);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult Add2(Trip newTrip)
        {
            if (ModelState.IsValid)
            {
                TempData["DestinationId"] = newTrip.DestinationId;
                TempData["AccommodationId"] = newTrip.AccommodationId;
                TempData["StartDate"] = newTrip.StartDate;
                TempData["EndDate"] = newTrip.EndDate;

                
                Destination dest = context.Destinations.Find(newTrip.DestinationId);

                ViewBag.Activities = context.Activities.OrderBy(a => a.ActivityName).ToList();

                TempData["Destination"] = dest.DestinationName;
                return View("Page2");
                
            }
            
            else
            {
                return View("Page1", new Trip());
            }
                

        }

        [HttpPost]
        public IActionResult Add(int[] select)
        {

            Trip newTrip = new Trip();

            
            newTrip.DestinationId = (int)TempData["DestinationId"];

            
            newTrip.AccommodationId = (int)TempData["AccommodationId"];
            newTrip.StartDate = (DateTime)TempData.Peek("StartDate");
            newTrip.EndDate = (DateTime)TempData.Peek("EndDate");

            context.Trips.Add(newTrip);
            context.SaveChanges();

            var trip = context.Trips.Where(t => t.DestinationId == newTrip.DestinationId);
            trip.Where(t => t.AccommodationId == newTrip.AccommodationId);
            trip.Where(t => t.StartDate == (DateTime)TempData["StartDate"]);
            int id = trip.Where(t => t.EndDate == (DateTime)TempData["EndDate"]).FirstOrDefault().TripId;

            foreach (int integer in select)
            {
                TripActivity newTripActivity = new TripActivity();

                newTripActivity.ActivityId = integer;
                newTripActivity.TripId = id;

                context.TripActivities.Add(newTripActivity);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
           
        }
       
    }
}
