namespace HotelCollab.Services
{
    using HotelCollab.Data;
    using HotelCollab.Data.Models;
    using HotelCollab.Services.Interfaces;
    using HotelCollab.ViewModels.Hotel;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    public class HotelService : IHotelService
    {
        private readonly IRepository<Hotel> hotelRepo;
        private readonly IRepository<Town> townRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<ApplicationUser> repository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public HotelService(IRepository<Hotel> hotelRepo, IRepository<Town> townRepo, UserManager<ApplicationUser> userManager, IRepository<ApplicationUser> repository,IHttpContextAccessor httpContextAccessor)
        {
            this.hotelRepo = hotelRepo;
            this.townRepo = townRepo;
            this.userManager = userManager;
            this.repository = repository;
            this.httpContextAccessor = httpContextAccessor;


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

            var currentUser = httpContextAccessor.HttpContext.User;
            var id =  userManager.GetUserId(currentUser);
            var user = repository.Get(id);
            Task.Run(()=>
            {
            });

            
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
               // UserRoles = new ApplicationUserRole { }
            };

            hotelRepo.Add(hotel);
            hotelRepo.SaveChanges();
        }
    }
}
