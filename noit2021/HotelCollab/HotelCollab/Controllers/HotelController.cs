namespace HotelCollab.Web.Controllers
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using HotelCollab.Data;
    using HotelCollab.Data.Models;
    using HotelCollab.Presentation;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    public class HotelController : Controller
    {
        private readonly IRepository<Hotel> repoTown;

        public HotelController(IRepository<Hotel> repoTown)
        {
            this.repoTown = repoTown;
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterHotel(HotelRegisterViewModel hotel)
        {

            var townId = string.Empty;

            //if (db.Towns.Where(town => town.Name == hotel.TownName).Any())
            //{
            //    var town = new Town() { Name = hotel.TownName };
            //    townId = town.TownId;
            //    await db.SaveChangesAsync();
            //}
            //else
            //{
            //    townId = db
            //        .Towns
            //        .Where(town => town.Name == hotel.TownName)
            //        .FirstOrDefault()
            //        .TownId;
            //}

            //var account = new Account { ApiKey = "597981955165718", ApiSecret = "YrIRgn7E7ffUnN1kXSJhyGQJS54", Cloud = "hotelcollab" };

            //var cloudinary = new Cloudinary(account);

            //var uploadParams = new ImageUploadParams()
            //{
            //    File = new FileDescription(@$"{hotel.Name.ToLower()}.jpg"),
            //};

            //var result = cloudinary.Upload(uploadParams);

            //var newHotel = new Hotel(result.Url.ToString())
            //{
            //    Name = hotel.Name,
            //    PhoneNumber = hotel.PhoneNumber,
            //    TownId = townId,
            //    Address = hotel.Address,
            //    CleaningPeriod = hotel.CleaningPeriod,
            //};

            //db.Hotels.Add(newHotel);

            //await db.SaveChangesAsync();

            return this.Redirect("/Home/Index");
        }
    }
}
