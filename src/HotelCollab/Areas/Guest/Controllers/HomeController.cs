using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Areas.Guest.Controllers
{
    public class HomeController : Controller
    {
        [Area("Guest")]
        public IActionResult Reservation()
        {
            return this.View();
        }
    }
}
