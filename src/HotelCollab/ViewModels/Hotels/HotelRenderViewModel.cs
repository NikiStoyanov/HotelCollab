using HotelCollab.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.ViewModels.Hotels
{
    public class HotelRenderViewModel
    {
        public Hotel Hotel { get; set; }

        public string Role { get; set; }

        public List<Hotel> Hotels { get; set; }

        public string HotelId { get; set; }
    }
}
