namespace HotelCollab.Controllers
{
    using HotelCollab.Data;
    using HotelCollab.Data.Models;
    using HotelCollab.Services.Interfaces;
    using HotelCollab.ViewModels.Hotels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly IHotelService hotelService;
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<Town> townRepo;

        public HomeController(IHotelService hotelService, IUserService userService, UserManager<ApplicationUser> userManager,IRepository<Town> townRepo)
        {
            this.hotelService = hotelService;
            this.userService = userService;
            this.userManager = userManager;
            this.townRepo = townRepo;
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                //var id = this.userManager.GetUserId(this.User);

                //var UserViewModel = new UserDashboardViewModel()
                //{
                //    FirstName = await userService.GetUserFirstNameAsync(id),
                //};

                var userId=this.User.Claims.FirstOrDefault(x => x.Type == "Id");

                var listOfViews = new List<HotelRenderViewModel>();

                var hotels = await hotelService.GetAllHotelsAsync();

                foreach (var item in hotels)
                {
                    var temp = item.UserHotels.FirstOrDefault(x => x.UserId == userId.Value);
                    listOfViews.Add(new HotelRenderViewModel { Hotel=item,Role=item.UserHotels.FirstOrDefault(x=>x.UserId==userId.Value).Role.Name});
                }

                var result = new object();

                return this.View("Dashboard", result);
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
