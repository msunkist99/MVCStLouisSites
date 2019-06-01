using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCStLouisSites.ViewModels.DisplayAttractions;

namespace MVCStLouisSites.Controllers
{
    public class AttractionSplashController : Controller
    {
        public IActionResult Index(int id)
        {
            AttractionSplashIndexViewModel model = AttractionSplashIndexViewModel.GetAttractionSplashViewModelById(id);

            return View(model);
        }
    }
}