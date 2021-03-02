using HotelCollab.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [Authorize]
        [Area("Manager")]
        public IActionResult Cleanings()
        {
            return View();
        }

        [Authorize]
        [Area("Manager")]
        public IActionResult Events()
        {
            return View();
        }

        [Authorize]
        [Area("Manager")]
        public IActionResult Signals()
        {
            return View();
        }
    }
}
