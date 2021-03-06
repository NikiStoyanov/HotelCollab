﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Areas.Manager.Controllers
{
    public class ReservationController : Controller
    {
        [Authorize]
        [Area("Manager")]
        public IActionResult All()
        {
            return View();
        }

        [Authorize]
        [Area("Manager")]
        public IActionResult Add()
        {
            return View();
        }
    }
}
