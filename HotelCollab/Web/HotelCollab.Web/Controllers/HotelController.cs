namespace HotelCollab.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class HotelController : Controller
    {
        public IActionResult Register()
        {
            return this.View();
        }
    }
}
