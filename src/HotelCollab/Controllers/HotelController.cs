﻿namespace HotelCollab.Controllers
{
    using HotelCollab.Data;
    using HotelCollab.Data.Models;
    using HotelCollab.Services;
    using HotelCollab.Services.Interfaces;
    using HotelCollab.ViewModels.Hotels;
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
        public async Task<IActionResult> RegisterHotel(HotelRegisterViewModel model)
        {
            model.Image = Request.Form.Files["image"];

            await hotelService.AddHotelAsync(model);

            return this.Redirect("/Home/Index");
        }
    }
}
