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
        private readonly IRepository<ApplicationUser> userRepo;

        public HomeController(IHotelService hotelService, IUserService userService, UserManager<ApplicationUser> userManager, IRepository<Town> townRepo, IRepository<ApplicationUser> userRepo)
        {
            this.hotelService = hotelService;
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
                //var id = this.userManager.GetUserId(this.User);

                var userId = this.User.FindFirst("Id").Value;


                var hotels = await hotelService.GetAllHotelsAsync();

                var model = new GetHotelsViewModel() { Hotels = hotels };

                //var hotels2 = new GetHotelsViewModel()
                //{
                //    Hotels = await hotelService.GetAllHotelsAsync(),
                //};

                //var users = await userRepo.GetAllAsync();

                //foreach (var item in hotels)
                //{
                //    var temp = item.UserHotels.FirstOrDefault(x => x.UserId == userId.Value);
                //    listOfViews.Add(new HotelRenderViewModel { Hotel=item,Role=item.UserHotels.FirstOrDefault(x=>x.UserId==userId.Value).Role.Name});
                //}
                return this.View("Dashboard", model);
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
