using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCStLouisSites.ViewModels.AttractionViewModels;

namespace MVCStLouisSites.Controllers
{
    public class AttractionController : Controller
    {
        public IActionResult Index()
        {
            List<AttractionIndexViewModel> models = AttractionIndexViewModel.GetAttractionIndexViewModels();
            return View(models);
        }
    }
}