using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCStLouisSites.ViewModels.StLouisSites;

namespace MVCStLouisSites.Controllers
{
    public class StLouisSitesController : Controller
    {
        public IActionResult Index()
        {
            List<StLouisSitesIndexViewModel> models = StLouisSitesIndexViewModel.GetStLouisSitesIndexViewModel();
            return View(models);
        }
    }
}