using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCStLouisSites.Data;
using MVCStLouisSites.ViewModels.AttractionFeatureViewModels;

namespace MVCStLouisSites.Controllers
{
    public class AttractionFeatureController : Controller
    {
        private ApplicationDbContext context;

        // constructor so EF can pass in the ApplictionDBContext
        public AttractionFeatureController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            AttractionFeatureCreateViewModel attractionFeatureViewModel = new AttractionFeatureCreateViewModel();
            return View(attractionFeatureViewModel);
        }

        [HttpPost]
        public IActionResult Create(AttractionFeatureCreateViewModel attractionFeatureViewModel)
        {
            if (ModelState.IsValid)
            {
                AttractionFeatureCreateViewModel.CreateAttractionFeature(context, attractionFeatureViewModel);
                return RedirectToAction(nameof(Index), "Attraction");
            }

            return View(attractionFeatureViewModel);
        }

    }
}