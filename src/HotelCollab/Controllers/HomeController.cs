namespace HotelCollab.Controllers
{
    using HotelCollab.ViewModels.User;
    using HotelCollab.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using HotelCollab.Services.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using HotelCollab.Data.Models;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                //var user = this.User.Identity.Name.;

                var id = this.userManager.GetUserId(this.User);

                var UserViewModel = new UserDashboardViewModel()
                {
                    Name = await userService.GetUserFirstNameAsync(id),
                };

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
            return this.View();
            //new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
