using ProductWeb.Models;
using System.Threading.Tasks;

namespace ProductWeb.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> ValidateUser(string username, string password);
        Task<User> CreateUser(User newUser);
        Task<User> GetUserByUsername(string username); 
    }
}