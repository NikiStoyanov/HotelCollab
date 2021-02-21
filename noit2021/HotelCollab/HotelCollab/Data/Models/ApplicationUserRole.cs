namespace HotelCollab.Data.Models
{

    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public string HotelId { get; set; }
       
        public Hotel Hotel { get; set; }
    }
}
