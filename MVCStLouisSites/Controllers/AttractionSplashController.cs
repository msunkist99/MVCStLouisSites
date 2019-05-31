using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCStLouisSites.Controllers
{
    public class AttractionSplashController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}