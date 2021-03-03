namespace HotelCollab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Cleaning
    {
        public Cleaning()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string RoomId { get; set; }

        public virtual Room Room { get; set; }

        public string CleanerId { get; set; }

        public virtual ApplicationUser Cleaner { get; set; }

        public bool IsDamaged { get; set; }

        public virtual ICollection<Damage> Damages { get; set; }
    }
}
