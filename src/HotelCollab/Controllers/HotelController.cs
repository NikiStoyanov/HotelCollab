namespace HotelCollab.Controllers
{
    using HotelCollab.Data;
    using HotelCollab.Data.Models;
    using HotelCollab.Services;
    using HotelCollab.Services.Interfaces;
    using HotelCollab.ViewModels.Hotel;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class HotelController : Controller
    {
        private readonly IHotelService hotelService;

        public HotelController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult RegisterHotel(HotelRegisterViewModel model)
        {
            hotelService.AddHotel(model);

            return this.Redirect("/Home/Index");
        }
    }
}
