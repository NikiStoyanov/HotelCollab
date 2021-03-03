using HotelCollab.Areas.Manager.ViewModels;
using HotelCollab.Attributes;
using HotelCollab.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelCollab.Areas.Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventService eventService;

        public HomeController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [Authorize]
        [Area("Manager")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [Authorize]
        [Area("Manager")]
        [HttpGet]
        public IActionResult Cleanings()
        {
            return View();
        }

        [Authorize]
        [Area("Manager")]
        public IActionResult Events()
        {
            return View();
        }

        [Authorize]
        [Area("Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventViewModel model)
        {
            await eventService.AddEventAsync(model);

            return Redirect("/Manager/Home/Events");
        }

        [Authorize]
        [Area("Manager")]
        public IActionResult Signals()
        {
            return View();
        }
    }
}
