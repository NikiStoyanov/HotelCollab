namespace HotelCollab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        public Town()
        {
            this.TownId = Guid.NewGuid().ToString();

            this.Hotels = new HashSet<Hotel>();
        }

        public string TownId { get; private set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
