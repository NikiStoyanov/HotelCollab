namespace HotelCollab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Damage
    {
        public Damage()
        {
            this.DamageId = Guid.NewGuid().ToString();
        }

        public string DamageId { get; private set; }

        public string CleaningId { get; set; }

        public string Content { get; set; }
    }
}
