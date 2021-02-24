using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Areas.Guest.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        [Area("Guest")]
        public IActionResult Reservation()
        {
            return this.View();
        }

        [Authorize]
        [Area("Guest")]
        public IActionResult Signal()
        {
            return this.View();
        }

        [Authorize]
        [Area("Guest")]
        public IActionResult Events()
        {
            return this.View();
        }
    }
}
