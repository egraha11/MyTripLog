using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using MyTripLog.Models;
//using MyTripLog.Models.ViewModel;

namespace MyTripLog.Controllers
{
    public class ManageController : Controller
    {

        private UnitOfWork data { get; set; }

        public ManageController(TripContext ctx) => data = new UnitOfWork(ctx);

        public IActionResult Index()
        {
            var vm = new ManageViewModel();

            LoadDropDownData(vm);

            return View(vm);
        }


        [HttpPost]
        public RedirectToActionResult Add(ManageViewModel vm)
        {
            bool needsSave = false;
            string notifying = string.Empty;

            if (!string.IsNullOrEmpty(vm.Destination.Name))
            {
                data.Destinations.Insert(vm.Destination);
                notifying = $"{vm.Destination.Name}";
                needsSave = true;
            }
            if (!string.IsNullOrEmpty(vm.Accommodation.Name))
            {
                data.Accommodations.Insert(vm.Accommodation);
                notifying = $"{vm.Destination.Name}";
                needsSave = true;
            }
            if (!string.IsNullOrEmpty(vm.Activity.Name))
            {
                data.Activities.Insert(vm.Activity);
                notifying = $"{vm.Activity.Name}";
                needsSave = true;
            }
            if (needsSave)
            {
                data.Save();
                TempData["message"] = notifying + " added";
            }

            return RedirectToAction("Confirm");
        }


        [HttpPost]
        public IActionResult Delete(ManageViewModel vm)
        {
            bool needsSave = false;
            string notifying = string.Empty;

            if (vm.Destination.DestinationId > 0)
            {
                vm.Destination = data.Destinations.Get(vm.Destination.DestinationId);
                data.Destinations.Delete(vm.Destination);
                notifying = $"{vm.Destination.Name}";
                needsSave = true;
            }
            if (vm.Accommodation.AccommodationId > 0)
            {
                vm.Accommodation = data.Accommodations.Get(vm.Accommodation.AccommodationId);
                data.Accommodations.Delete(vm.Accommodation);
                notifying = $"{vm.Accommodation.Name}";
                needsSave = true;
            }
            if (vm.Activity.ActivityId > 0)
            {
                vm.Activity = data.Activities.Get(vm.Activity.ActivityId);
                data.Activities.Delete(vm.Activity);
                notifying = $"{vm.Activity.Name}";
                needsSave = true;
            }
            if (needsSave)
            {
                try
                {
                    data.Save();
                    TempData["message"] = notifying + " deleted";
                }
                catch
                {
                    TempData["message"] = $"Unable to delte {vm.Destination.Name} because it is associated with a trip.";
                    LoadDropDownData(vm);
                    return View("Index", vm);
                }

            }

            return RedirectToAction("Confirm");
        }

        public ViewResult Confirm() => View();

        private void LoadDropDownData(ManageViewModel vm)
        {
            vm.Destinations = data.Destinations.List(new QueryOptions<Destination>
            {
                OrderBy = data => data.Name
            });

            vm.Accommodations = data.Accommodations.List(new QueryOptions<Accommodation>
            {
                OrderBy = a => a.Name
            });

            vm.Activities = data.Activities.List(new QueryOptions<Activity>
            {
                OrderBy = a => a.Name
            });
        }
    }
}
