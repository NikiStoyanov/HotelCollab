using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Areas.Receptionist.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        [Area("Receptionist")]
        public IActionResult Index()
        {
            return View("Dashboard");
        }

        [Authorize]
        [Area("Receptionist")]
        public IActionResult Signals()
        {
            return View();
        }

        [Authorize]
        [Area("Receptionist")]
        public IActionResult Cleanings()
        {
            return View();
        }

        [Authorize]
        [Area("Receptionist")]
        public IActionResult Reservations()
        {
            return View();
        }
    }
}
