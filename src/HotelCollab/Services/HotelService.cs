namespace HotelCollab.Services
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using HotelCollab.Data;
    using HotelCollab.Data.Models;
    using HotelCollab.Services.Interfaces;
    using HotelCollab.ViewModels.Hotels;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    public class HotelService : IHotelService
    {
        private readonly IRepository<Hotel> hotelRepo;
        private readonly IRepository<Town> townRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<Request> repository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HotelService(IRepository<Hotel> hotelRepo, IRepository<Town> townRepo, UserManager<ApplicationUser> userManager, IRepository<Request> repository,IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            this.hotelRepo = hotelRepo;
            this.townRepo = townRepo;
            this.userManager = userManager;
            this.repository = repository;
            this.httpContextAccessor = httpContextAccessor;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task AddHotelAsync(HotelRegisterViewModel model)
        {
            //var account = new Account { ApiKey = "597981955165718", ApiSecret = "YrIRgn7E7ffUnN1kXSJhyGQJS54", Cloud = "hotelcollab" };

            //var cloudinary = new Cloudinary(account);

            //var uploadParams = new ImageUploadParams()
            //{
            //    File = new FileDescription(Path.Combine(Path.GetFullPath(model.Image.Name))),
            //};

            //var result = cloudinary.Upload(uploadParams);

            //var currentUser = httpContextAccessor.HttpContext.User;

            //Task.Run(()=>
            //{
            //});

            var town = new Town
            {
                Name=model.TownName
            };
            

           await townRepo.AddAsync(town);
            var allRequests = await repository.GetAllAsync();
            var hotel = new Hotel(string.Empty)
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                CleaningPeriod = model.CleaningPeriod,
                TownId = town.Id,
            };
            town.Hotels.Add(hotel);
            hotel.UserHotels.Add(new UserHotels { Hotel=hotel,UserId= httpContextAccessor.HttpContext.User.FindFirst("Id").Value});

            await townRepo.SaveChangesAsync();
            await hotelRepo.SaveChangesAsync();
        }

        public async Task<List<Hotel>> GetAllHotelsAsync() => await hotelRepo.GetAllAsync();
    }
}
