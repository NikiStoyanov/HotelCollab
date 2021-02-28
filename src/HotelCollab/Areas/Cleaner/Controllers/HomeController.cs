using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Areas.Cleaner.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        [Area("Cleaner")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
