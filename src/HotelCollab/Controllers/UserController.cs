using HotelCollab.Services.Interfaces;
using HotelCollab.ViewModels.Hotels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Controllers
{
    public class UserController : Controller
    {
        private readonly IRequestService requestService;

        public UserController(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(GetHotelsViewModel model)
        {
            await requestService.CreateRequestAsync(model);

            return this.Redirect("/Home/Index");
        }
    }
}
