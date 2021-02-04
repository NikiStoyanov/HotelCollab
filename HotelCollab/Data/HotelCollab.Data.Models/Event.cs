namespace HotelCollab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Event
    {
        public Event()
        {
            this.EventId = Guid.NewGuid().ToString();
        }

        public string EventId { get; private set; }

        [Required]
        [Range(20, 50)]
        public string Title { get; set; }

        [Required]
        [Range(100, 300)]
        public string Description { get; set; }

        [Required]
        public string HotelId { get; set; }

        public Hotel Hotel { get; set; }
    }
}
