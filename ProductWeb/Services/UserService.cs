using ProductWeb.Models;
using ProductWeb.Repositories.Interfaces;
using ProductWeb.Services.Interfaces;
using System.Threading.Tasks;

namespace ProductWeb.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> ValidateUser(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }

        public async Task<User> CreateUser(User newUser)
        {
            return await _userRepository.CreateAsync(newUser);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }
    }
}
