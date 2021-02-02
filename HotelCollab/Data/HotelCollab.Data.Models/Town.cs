namespace HotelCollab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Town
    {
        public Town()
        {
            this.TownId = Guid.NewGuid().ToString();
        }

        public string TownId { get; private set; }

        public string Name { get; set; }
    }
}
