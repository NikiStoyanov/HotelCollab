﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Areas.Manager.Controllers
{
    public class EmployeeController : Controller
    {
        [Authorize]
        [Area("Manager")]
        public IActionResult Overview()
        {
            return View();
        }
    }
}
