using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCStLouisSites.Data;
using MVCStLouisSites.ViewModels.AttractionViewModels;
using MVCStLouisSites.ViewModels.LocationViewModels;

namespace MVCStLouisSites.Controllers
{
    public class LocationController : Controller
    {
        private ApplicationDbContext context;

        // constructor so EF can pass in the ApplictionDBContext
        public LocationController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(int Id)
        {
            LocationCreateViewModel locationViewModel = new LocationCreateViewModel(context, Id);
            return View(locationViewModel);
        }

        [HttpPost]
        public IActionResult Create(LocationCreateViewModel locationViewModel)
        {
            if (ModelState.IsValid)
            {
                LocationCreateViewModel.CreateLocation(context, locationViewModel);
                return RedirectToAction(nameof(Index), "Attraction");
            }

            return View(locationViewModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            LocationUpdateViewModel locationViewModel = LocationUpdateViewModel.GetLocationById(context, id);
            return View(locationViewModel);
        }

        [HttpPost]
        public IActionResult Update(LocationUpdateViewModel locationViewModel)
        {
            if (ModelState.IsValid)
            {
                LocationUpdateViewModel.UpdateLocation(context, locationViewModel);
                return RedirectToAction(nameof(Index), "Attraction");
            }

            return View(locationViewModel);
        }

        [HttpGet]
        // this doesn't seem secure using HttpGet
        public IActionResult Delete(int id)
        {
            LocationUpdateViewModel.DeleteLocationById(context, id);
            return RedirectToAction(nameof(Index), "Attraction");
        }

    }
}