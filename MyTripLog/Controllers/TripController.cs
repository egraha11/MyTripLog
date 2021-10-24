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
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Add()
        {


            return View("Page1", new Trip());
        }


        [HttpPost]
        public IActionResult Add(Trip newTrip, string id = "Complete")
        {

            TempData["Destination"] = newTrip.Destination;
            TempData["StartDate"] = newTrip.StartDate;
            TempData["EndDate"] = newTrip.EndDate;
            TempData["Accommodation"] = newTrip.Accommodation;
            TempData["AccommodationPhone"] = newTrip.AccommodationPhone;
            TempData["AccommodationEmail"] = newTrip.AccommodationEmail;
            TempData["ThingToDo1"] = newTrip.ThingToDo1;
            TempData["ThingToDo2"] = newTrip.ThingToDo2;
            TempData["ThingToDo3"] = newTrip.ThingToDo3;

            if (ModelState.IsValid)
            {
                if (id == "Complete")
                {
                    return RedirectToAction("AddData", "Home");
                }
                else if (TempData.Peek("Accommodation") != null && id == "Page2")
                {
                    ViewBag.Accommodation = (string)TempData.Peek("Accommodation");

                    Trip trip = new Trip();

                    trip.Destination = (string)TempData["Destination"];
                    trip.StartDate = (DateTime)TempData["StartDate"];
                    trip.EndDate = (DateTime)TempData["EndDate"];
                    trip.Accommodation = (string)TempData["Accommodation"];

                    return View("Page2", trip);
                }
                else
                {
                    ViewBag.Destination = (string)TempData.Peek("Destination");

                    Trip trip = new Trip();

                    trip.Destination = (string)TempData["Destination"];
                    trip.StartDate = (DateTime)TempData["StartDate"];
                    trip.EndDate = (DateTime)TempData["EndDate"];
                    trip.Accommodation = (string)TempData["Accommodation"];
                    trip.AccommodationEmail = (string)TempData["AccommodationEmail"];
                    trip.AccommodationPhone = (string)TempData["AccommodationPhone"];

                    return View("Page3", trip);
                }
            }
            else
            {
                return View("Page1", newTrip);
            }



        }
    }
}
