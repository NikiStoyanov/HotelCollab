namespace HotelCollab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Cleaning
    {
        public Cleaning()
        {
            this.CleaningId = Guid.NewGuid().ToString();
        }

        public string CleaningId { get; set; }

        public string RoomId { get; set; }

        public Room Room { get; set; }

        public string CleanerId { get; set; }

        public ApplicationUser Cleaner { get; set; }

        public bool IsDamaged { get; set; }

        public virtual ICollection<Damage> Damages { get; set; }

        // finish cleaning and damages in OnModelCreating and finish the DbSets
    }
}
