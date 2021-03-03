using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Data.Models
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public string HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
