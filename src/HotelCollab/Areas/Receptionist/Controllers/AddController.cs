using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Areas.Receptionist.Controllers
{
    public class AddController : Controller
    {
        [Authorize]
        [Area("Receptionist")]
        public IActionResult Guest()
        {
            return View();
        }

        [Authorize]
        [Area("Receptionist")]
        public IActionResult Event()
        {
            return View();
        }
    }
}
