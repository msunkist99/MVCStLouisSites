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
        public IActionResult Create(int attractionId)
        {
            LocationCreateViewModel locationViewModel = new LocationCreateViewModel(context, attractionId);
            return View(locationViewModel);
        }

        [HttpPost]
        public IActionResult Create(LocationCreateViewModel attraction)
        {
            LocationCreateViewModel.CreateLocation(context, attraction);

            return RedirectToAction(nameof(Index), "Attraction");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            LocationUpdateViewModel locationViewModel = LocationUpdateViewModel.GetLocationById(context, id);
            return View(locationViewModel);
        }

        [HttpPost]
        public IActionResult Update(LocationUpdateViewModel location)
        {
            LocationUpdateViewModel.UpdateLocation(context, location);

            return RedirectToAction(nameof(Index), "Attraction");
        }

    }
}