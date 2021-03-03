using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Data.Models
{
    public class UserHotels
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        public string RoleId { get; set; }

        public virtual ApplicationRole Role { get; set; }
    }
}
