using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyTripLog.Models;

namespace MyTripLog.Controllers
{
    public class HomeController : Controller
    {
        private TripContext context { get; set; }

        private readonly ILogger<HomeController> _logger;

        /**
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        **/

        public HomeController(TripContext ctx)
        {
            context = ctx;
        }

        public ViewResult Index()
        {

            var trips = context.Trips.OrderBy(t => t.Destination).ToList();
            return View(trips);
        }

        public RedirectToActionResult AddData()
        {

            Trip newTrip = new Trip();

            newTrip.Destination = (string)TempData.Peek("Destination");
            newTrip.StartDate = (DateTime)TempData["StartDate"];
            newTrip.EndDate = (DateTime)TempData["EndDate"];
            newTrip.Accommodation = (string)TempData["Accommodation"];
            newTrip.AccommodationEmail = (string)TempData["AccommodationEmail"];
            newTrip.AccommodationPhone = (string)TempData["AccommodationPhone"];
            newTrip.ThingToDo1 = (string)TempData["ThingToDo1"];
            newTrip.ThingToDo2 = (string)TempData["ThingToDo2"];
            newTrip.ThingToDo3 = (string)TempData["ThingToDo3"];

            TempData["Added"] = newTrip.Destination;

            context.Trips.Add(newTrip);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public RedirectToActionResult Clear()
        {
            TempData.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
