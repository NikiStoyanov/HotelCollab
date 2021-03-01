using HotelCollab.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HotelCollab.Services
{
    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public MyUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            IOptions<IdentityOptions> optionsAccessor)
                : base(userManager, optionsAccessor)
        {
            this.userManager = userManager;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var isManager = await this.UserManager.IsInRoleAsync(user, "Manager");
            var isGuest = await this.UserManager.IsInRoleAsync(user, "Guest");
            var isReceptionist = await this.UserManager.IsInRoleAsync(user, "Receptionist");
            var isCleaner = await this.UserManager.IsInRoleAsync(user, "Cleaner");
            var isAdmin = await this.UserManager.IsInRoleAsync(user, "Admin");

            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("FirstName", user.FirstName));
            identity.AddClaim(new Claim("LastName", user.LastName));
            identity.AddClaim(new Claim("Id", user.Id));
            //identity.AddClaim(new Claim("Role", user.Roles.First().RoleId));
            identity.AddClaim(new Claim("IsManager", isManager.ToString()));
            identity.AddClaim(new Claim("IsGuest", isGuest.ToString()));
            identity.AddClaim(new Claim("IsReceptionist", isReceptionist.ToString()));
            identity.AddClaim(new Claim("IsCleaner", isCleaner.ToString()));
            identity.AddClaim(new Claim("IsAdmin", isAdmin.ToString()));

            return identity;
        }
    }
}
