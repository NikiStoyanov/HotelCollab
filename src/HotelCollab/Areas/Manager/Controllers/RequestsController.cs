using HotelCollab.Data;
using HotelCollab.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Areas.Manager.Controllers
{
    public class RequestsController : Controller
    {
        private readonly IRepository<UserHotels> userHotelsRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<Request> requestRepo;
        private readonly IRepository<ApplicationUser> userRepo;
        private readonly IRepository<ApplicationRole> roleRepo;

        public RequestsController(IRepository<UserHotels> userHotelsRepo, UserManager<ApplicationUser> userManager, IRepository<Request> requestRepo, IRepository<ApplicationUser> userRepo, IRepository<ApplicationRole> roleRepo)
        {
            this.userHotelsRepo = userHotelsRepo;
            this.userManager = userManager;
            this.requestRepo = requestRepo;
            this.userRepo = userRepo;
            this.roleRepo = roleRepo;
        }

        [Authorize]
        [Area("Manager")]
        [HttpPost]
        public async Task<IActionResult> Finish(string id)
        { 
            var request = (await requestRepo.GetAllAsync()).FirstOrDefault(r => r.Id == id);

            var role = (await roleRepo.GetAllAsync()).FirstOrDefault(r => r.Name == request.Role);

            var user = await userRepo.GetAsync(request.UserId);

            var userHotels = new UserHotels()
            {
                UserId = request.UserId,
                HotelId = request.HotelId,
                RoleId = role.Id,
            };

            await this.userManager.AddToRoleAsync(user, role.Name);
            await userHotelsRepo.AddAsync(userHotels);
            await userHotelsRepo.SaveChangesAsync();

            requestRepo.Delete(request);
            await requestRepo.SaveChangesAsync();

            return Redirect("/Manager/Users/Requests");
        }
    }
}
