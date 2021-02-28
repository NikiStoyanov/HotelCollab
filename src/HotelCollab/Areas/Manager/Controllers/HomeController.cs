using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Areas.Manager.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Manager")]
        [Area("Manager")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        [Area("Manager")]
        public IActionResult CLeanings()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        [Area("Manager")]
        public IActionResult Events()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        [Area("Manager")]
        public IActionResult Signals()
        {
            return View();
        }
    }
}
