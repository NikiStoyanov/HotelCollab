namespace HotelCollab.Data.Models
{

    using Microsoft.AspNetCore.Identity;
    using System;

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public string HotelId { get; set; }

        public Hotel Hotel { get; set; }
    }
}
