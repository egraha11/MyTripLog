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

        public HomeController(TripContext ctx)
        {
            context = ctx;
        }

        public ViewResult Index()
        {
            IEnumerable<Trip> trips = context.Trips.OrderBy(t => t.Destination).ToList();

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

        /**
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        **/
    }
}
