using HotelCollab.Areas.Manager.ViewModels;
using HotelCollab.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Areas.Manager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IRequestService requestService;

        public UsersController(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        [Authorize]
        [Area("Manager")]
        public IActionResult Employees()
        {
            return View();
        }

        [Authorize]
        [Area("Manager")]
        public async Task<IActionResult> Requests()
        {
            var result = new RequestsViewModel()
            {
                Requests =( await requestService.GetAllRequestsAsync()),
            };

            return this.View(result);
        }
    }
}
