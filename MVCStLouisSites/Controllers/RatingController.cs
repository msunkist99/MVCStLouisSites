using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCStLouisSites.Data;
using MVCStLouisSites.ViewModels.RatingViewModels;

namespace MVCStLouisSites.Controllers
{
    public class RatingController : Controller
    {
        private ApplicationDbContext context;

        // constructor so EF can pass in the ApplictionDBContext
        public RatingController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            RatingCreateViewModel ratingViewModel = new RatingCreateViewModel(context, id);
            return View(ratingViewModel);
        }

        [HttpPost]
        public IActionResult Create(RatingCreateViewModel ratingViewModel)
        {
            RatingCreateViewModel.CreateRating(context, ratingViewModel);

            return RedirectToAction(nameof(Index), "Attraction");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            RatingUpdateViewModel ratingViewModel = RatingUpdateViewModel.GetRatingById(context, id);
            return View(ratingViewModel);
        }

        [HttpPost]
        public IActionResult Update(RatingUpdateViewModel rating)
        {
            RatingUpdateViewModel.UpdateRating(context, rating);

            return RedirectToAction(nameof(Index), "Attraction");
        }
    }
}