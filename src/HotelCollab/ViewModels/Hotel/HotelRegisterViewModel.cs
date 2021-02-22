﻿namespace HotelCollab.ViewModels.Hotel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class HotelRegisterViewModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Name { get; set; }

        [StringLength(12)]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string TownName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        public byte[] Image { get; set; }

        [Required]
        public int CleaningPeriod { get; set; }
    }
}
