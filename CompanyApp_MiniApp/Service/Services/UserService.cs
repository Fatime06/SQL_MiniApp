using Domain.Entities;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var userLogin = await _userRepository.GetAllAsync();
            var succesLogin = userLogin.Any(x => x.Email.ToLower() == email.ToLower() && x.Password.ToLower() == password.ToLower());
            return succesLogin;
        }

        public async Task RegisterAsync(User user)
        {
            await _userRepository.CreateAsync(user);
        }
    }
}
