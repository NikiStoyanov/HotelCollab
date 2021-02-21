namespace HotelCollab.Data.Models
{

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public string HotelId { get; set; }

        public Hotel Hotel { get; set; }
    }
}
