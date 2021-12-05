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
        public Repository<Trip> data { get; set; }
        public HomeController(TripContext ctx) => data = new Repository<Trip>(ctx);
        public ViewResult Index()
        {
            var options = new QueryOptions<Trip>
            {
                Includes = "Destination, Accommodation, TripActivities.Activity",
                OrderBy = t => t.StartDate
            };

            var trips = data.List(options);

            return View(trips);
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
    }
}
