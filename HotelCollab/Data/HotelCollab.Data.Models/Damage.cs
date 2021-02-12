﻿namespace HotelCollab.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Damage
    {
        public Damage()
        {
            this.DamageId = Guid.NewGuid().ToString();
        }

        public string DamageId { get; private set; }

        [Required]
        public string CleaningId { get; set; }

        public Cleaning Cleaning { get; set; }

        [Range(20, 250)]
        public string Content { get; set; }
    }
}