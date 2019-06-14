using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCStLouisSites.ViewModels.AttractionViewModels;
using MVCStLouisSites.Models;
using MVCStLouisSites.Data;

namespace MVCStLouisSites.Controllers
{
    public class AttractionController : Controller
    {
        private ApplicationDbContext context;

        // constructor so EF can pass in the ApplictionDBContext
        public AttractionController (ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<AttractionIndexViewModel> attractions = AttractionIndexViewModel.GetAttractions(context);
            return View(attractions);
        }

        public IActionResult Detail(int id)
        {
            AttractionUpdateViewModel attractionViewModel = AttractionUpdateViewModel.GetAttractionById(context, id);
            return View(attractionViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AttractionCreateViewModel attractionViewModel)
        {
            if (ModelState.IsValid)
            {
                AttractionCreateViewModel.CreateAttraction(context, attractionViewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(attractionViewModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            AttractionUpdateViewModel attractionViewModel = AttractionUpdateViewModel.GetAttractionById(context, id);
            return View(attractionViewModel);
        }

        [HttpPost]
        public IActionResult Update(AttractionUpdateViewModel attractionViewModel)
        {
            if (ModelState.IsValid)
            {
                AttractionUpdateViewModel.UpdateAttraction(context, attractionViewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(attractionViewModel);
        }

        [HttpGet]
        // this doesn't seem secure using HttpGet
        public IActionResult Delete(int id)
        {
            AttractionUpdateViewModel.DeleteAttractionById(context, id);
            return RedirectToAction(nameof(Index));
        }
    }
};