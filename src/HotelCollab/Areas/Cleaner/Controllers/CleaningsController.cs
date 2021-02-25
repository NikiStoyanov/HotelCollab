namespace HotelCollab.Areas.Cleaner.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CleaningsController : Controller
    {
        [Authorize]
        [Area("Cleaner")]
        public IActionResult Upcoming()
        {
            return View();
        }

        [Authorize]
        [Area("Cleaner")]
        public IActionResult Old()
        {
            return View();
        }
    }
}
