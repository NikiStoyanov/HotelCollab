namespace HotelCollab.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

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

        [Required]
        [MinLength(20)]
        [MaxLength(250)]
        public string Content { get; set; }
    }
}
