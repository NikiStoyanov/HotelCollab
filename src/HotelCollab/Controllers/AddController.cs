namespace HotelCollab.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HotelCollab.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AddController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;

        public AddController(RoleManager<ApplicationRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Role()
        {
            var roles = new string[5] { "Administrator", "Manager", "Receptionist", "Cleaner", "Guest" };

            foreach (var role in roles)
            {
                await this.roleManager.CreateAsync(new ApplicationRole()
                {
                    Name = role,
                });
            }

            return this.Redirect("/");
        }
    }
}
