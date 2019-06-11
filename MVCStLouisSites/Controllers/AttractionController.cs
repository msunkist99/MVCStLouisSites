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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AttractionCreateViewModel attraction)
        {
            if (ModelState.IsValid)
            {
                AttractionCreateViewModel.CreateAttraction(context, attraction);
                return RedirectToAction(nameof(Index));
            }

            return View(attraction);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            AttractionUpdateViewModel attraction = AttractionUpdateViewModel.GetAttractionById(context, id);
            return View(attraction);
        }

        [HttpPost]
        public IActionResult Update(AttractionUpdateViewModel attraction)
        {
            AttractionUpdateViewModel.UpdateAttraction(context, attraction);

            return RedirectToAction(nameof(Index));
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