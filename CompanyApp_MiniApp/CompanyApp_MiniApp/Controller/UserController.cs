using Domain.Entities;
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





        public async Task RegisterAsync()
        {
            try
            {
                var allUser = await _userService.GetAllAsync();

            UserName: Console.WriteLine("Enter fullname:");
                string fullName = Console.ReadLine();
                if (string.IsNullOrEmpty(fullName) || fullName.Trim().Length == 0)
                {
                    Console.WriteLine("Field can't be Empty!");
                    goto UserName;
                }
                if (string.IsNullOrWhiteSpace(fullName))
                {
                    Console.WriteLine("Please Enter the Name: ");
                    goto UserName;
                }
            UserMail: Console.WriteLine("Enter the email: ");
                string userEmail = Console.ReadLine();
                if (string.IsNullOrEmpty(userEmail))
                {
                    Console.WriteLine("Field can't be Empty!");
                    goto UserMail;
                }
                if (allUser.Any(x => x.Email == userEmail))
                {
                    Console.WriteLine("Email Already Exists, Please Enter Another One!");
                    goto UserMail;
                }
                if (string.IsNullOrWhiteSpace(userEmail) || !userEmail.Contains("@"))
                {
                    Console.WriteLine("Invalid Email Format. Please Try Again!");
                    goto UserMail;
                }

            Password: Console.WriteLine("Enter password:");
                string password = Console.ReadLine();
                if (string.IsNullOrEmpty(password) || password.Trim().Length == 0)
                {
                    Console.WriteLine("Confirm Password is Required! Please Try Again!");
                    goto Password;
                }
                if (!password.Any(char.IsDigit))
                {
                    Console.WriteLine("Password must contain at least one number!");
                    goto Password;
                }

            Confirm: Console.WriteLine("Enter confirm password:");
                string confirmPass = Console.ReadLine();
                if (string.IsNullOrEmpty(confirmPass) || confirmPass.Trim().Length == 0)
                {
                    Console.WriteLine("Confirm Password is Required! Please Try Again!");
                    goto Confirm;
                }
                if (confirmPass != password)
                {
                    Console.WriteLine("Passwords do not match. Please try again!");
                    goto Confirm;
                }

                await _userService.RegisterAsync(new User { FullName = fullName, Email = userEmail, Password = password });
                Console.WriteLine("User Created Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public async Task LoginAsync()
        {
            try
            {
            UserMail: Console.WriteLine("Enter email:");
                string userMail = Console.ReadLine();
                if (string.IsNullOrEmpty(userMail) || userMail.Trim().Length == 0)
                {
                    Console.WriteLine("Email Format is Wrong, Please Enter Again!");
                    goto UserMail;
                }
                if (string.IsNullOrWhiteSpace(userMail) || !userMail.Contains("@") || !userMail.Contains("."))
                {
                    Console.WriteLine("Email Format is Wrong, Please Enter Again!");
                }

            UserPass: Console.WriteLine("Enter password:");
                string password = Console.ReadLine();
                if (string.IsNullOrEmpty(password) || password.Trim().Length == 0)
                {
                    Console.WriteLine("Password Format is Wrong, Please Enter Again!");
                    goto UserPass;
                }
                var userLogin = await _userService.LoginAsync(userMail, password);
                if (userLogin)
                {
                    Login = true;
                    Console.WriteLine("Login Successfully!");
                }
                else
                {
                    Console.WriteLine("Login Failed!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
