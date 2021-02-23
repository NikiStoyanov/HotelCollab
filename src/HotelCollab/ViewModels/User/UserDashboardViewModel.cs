namespace HotelCollab.ViewModels.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HotelCollab.Data.Models;

    public class UserDashboardViewModel
    {
        public string Name { get; set; }

        public ICollection<Hotel> Hotels { get; set; }
    }
}
