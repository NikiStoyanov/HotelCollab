using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Areas.Manager.Controllers
{
    public class UsersController : Controller
    {
        [Authorize(Roles = "Manager")]
        [Area("Manager")]
        public IActionResult Employees()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        [Area("Manager")]
        public IActionResult Requests()
        {
            return View();
        }
    }
}
