using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Areas.Receptionist.Controllers
{
    public class ReservationController : Controller
    {
        [Authorize]
        [Area("Receptionist")]
        public IActionResult Control()
        {
            return View();
        }
    }
}
