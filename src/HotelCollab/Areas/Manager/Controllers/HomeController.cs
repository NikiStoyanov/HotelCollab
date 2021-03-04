using HotelCollab.Areas.Manager.ViewModels;
using HotelCollab.Attributes;
using HotelCollab.Data;
using HotelCollab.Data.Models;
using HotelCollab.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelCollab.Areas.Manager.Controllers
{
    public class HomeController : Controller
    {
        public string HotelId { get; set; }

        private readonly IEventService eventService;

        public HomeController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [Authorize]
        [Area("Manager")]
        public IActionResult Index(string id)
        {
            HotelId = id;

            return View("Dashboard");
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
            await eventService.AddEventAsync(model, this.HotelId);

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
