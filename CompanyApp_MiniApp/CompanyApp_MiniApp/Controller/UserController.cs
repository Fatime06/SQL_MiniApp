using Service.Services;
using Service.Services.Interfaces;

namespace CompanyApp_MiniApp.Controller
{
    public class UserController
    {
        public bool Login { get; set; }
        private readonly IUserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }



        public async Task GetAllAsync()
        {
            var allUser = await _userService.GetAllAsync();
            foreach (var item in allUser)
            {
                Console.WriteLine($"{item.Id},{item.FullName},{item.Email},{item.Password}");
            }
        }
    }
}
