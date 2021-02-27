namespace HotelCollab.Services
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using HotelCollab.Data;
    using HotelCollab.Data.Models;
    using HotelCollab.Services.Interfaces;
    using HotelCollab.ViewModels.Hotel;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using System.IO;
    using System.Threading.Tasks;

    public class HotelService : IHotelService
    {
        private readonly IRepository<Hotel> hotelRepo;
        private readonly IRepository<Town> townRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<ApplicationUser> repository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HotelService(IRepository<Hotel> hotelRepo, IRepository<Town> townRepo, UserManager<ApplicationUser> userManager, IRepository<ApplicationUser> repository,IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
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
            var account = new Account { ApiKey = "597981955165718", ApiSecret = "YrIRgn7E7ffUnN1kXSJhyGQJS54", Cloud = "hotelcollab" };

            var cloudinary = new Cloudinary(account);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(Path.Combine(Path.GetFullPath(model.Image.Name))),
            };

            var result = cloudinary.Upload(uploadParams);

            var currentUser = httpContextAccessor.HttpContext.User;
            var id =  userManager.GetUserId(currentUser);
            var user = await repository.GetAsync(id);

            //Task.Run(()=>
            //{
            //});

            var hotel = new Hotel(result.Url.ToString())
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                CleaningPeriod = model.CleaningPeriod,
            };

            hotel.Town.Name = model.TownName;

            await hotelRepo.AddAsync(hotel);
            await hotelRepo.SaveChangesAsync();
        }
    }
}
