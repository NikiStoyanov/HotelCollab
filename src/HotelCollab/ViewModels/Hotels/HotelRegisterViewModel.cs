namespace HotelCollab.ViewModels.Hotels
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using static System.Net.Mime.MediaTypeNames;

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

        [Required]
        public IFormFile Image { get; set; }

        [Required]
        public int CleaningPeriod { get; set; }
    }
}
