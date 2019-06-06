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
            //List<AttractionIndexViewModel> models = AttractionIndexViewModel.GetAttractionIndexViewModels();

            List<AttractionIndexViewModel> attractionIndexViewModels = AttractionIndexViewModel.GetAttractionIndexViewModels(context);
            return View(attractionIndexViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Attraction attraction)
            // you should really be passing in the AttractionCreateViewModel
        {
            context.Add(attraction);
            context.SaveChanges();

            return Redirect(nameof(Index));
        }
    }
};