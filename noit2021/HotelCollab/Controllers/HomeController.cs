namespace HotelCollab.Controllers
{
<<<<<<< HEAD:noit2021/HotelCollab/Controllers/HomeController.cs
=======
    using System.Diagnostics;
    using HotelCollab.Models;
    using Microsoft.AspNetCore.Authorization;
>>>>>>> 714d2209b2a9a86575bccfda9556e66651079782:HotelCollab/Web/HotelCollab.Web/Controllers/HomeController.cs
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController :  Controller
    {
        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.View("Dashboard");
            }
            else
            {
                return this.View();
            }
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
