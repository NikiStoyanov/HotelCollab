using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelCollab.Data.Models;

namespace HotelCollab.ViewModels.Hotels
{
    public class GetHotelsViewModel
    {
        public List<Hotel> Hotels { get; set; }

        public string HotelId { get; set; }

        public string Role { get; set; }
    }
}
