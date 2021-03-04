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
        private readonly IRepository<Hotel> hotelRepo;
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<Town> townRepo;
        private readonly IRepository<ApplicationUser> userRepo;

        public HomeController(IHotelService hotelService, IRepository<Hotel> hotelRepo, IUserService userService, UserManager<ApplicationUser> userManager, IRepository<Town> townRepo, IRepository<ApplicationUser> userRepo)
        {
            this.hotelService = hotelService;
            this.hotelRepo = hotelRepo;
            this.userService = userService;
            this.userManager = userManager;
            this.townRepo = townRepo;
            this.userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var userId = this.User.FindFirst("Id").Value;

                var currentUser = (await userRepo.GetAllAsync()).FirstOrDefault(x=>x.Id==userId);

                var list = new GetHotelsViewModel();

                list.Hotels = await hotelRepo.GetAllAsync();

                foreach (var item in currentUser.UserHotels)
                {
                    var action = string.Empty;

                    if (item.Role.Name=="Manager")
                    {
                        action = "Dashboard";
                    }

                    list.RenderedHotels.Add(new HotelRenderViewModel { Hotel=item.Hotel,Role=item.Role.Name,Action = action});
                }


                return this.View("Dashboard", list);
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
