using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Areas.Manager.ViewModels
{
    public class CreateEventViewModel
    {
        public string Title { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Description { get; set; }
    }
}
