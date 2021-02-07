namespace HotelCollab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HotelCollab.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class UserRole
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string RoleId { get; set; }

        public ApplicationRole Role { get; set; }

        public string HotelId { get; set; }

        public Hotel Hotel { get; set; }
    }
}
