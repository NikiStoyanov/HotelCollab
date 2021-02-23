namespace HotelCollab.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using HotelCollab.Data;
    using HotelCollab.Data.Models;
    using HotelCollab.Services.Interfaces;
    using HotelCollab.ViewModels.Hotel;

    public class HotelService : IHotelService
    {
        private readonly IRepository<Hotel> hotelRepo;
        private readonly IRepository<Town> townRepo;

        public HotelService(IRepository<Hotel> hotelRepo, IRepository<Town> townRepo)
        {
            this.hotelRepo = hotelRepo;
            this.townRepo = townRepo;
        }

        public void AddHotel(HotelRegisterViewModel model)
        {
            //var account = new Account { ApiKey = "597981955165718", ApiSecret = "YrIRgn7E7ffUnN1kXSJhyGQJS54", Cloud = "hotelcollab" };

            //var cloudinary = new Cloudinary(account);

            //var uploadParams = new ImageUploadParams()
            //{
            //    File = new FileDescription(@$"{model.Name.ToLower()}.jpg"),
            //};

            //var result = cloudinary.Upload(uploadParams);

            var hotel = new Hotel(string.Empty)
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                CleaningPeriod = model.CleaningPeriod,
                Town = new Town()
                {
                    Name = model.TownName,
                },
            };

            hotelRepo.Add(hotel);
        }
    }
}
