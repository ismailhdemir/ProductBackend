using System.Threading.Tasks;
using ProductWeb.Models;

namespace ProductWeb.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> CreateAsync(User newUser);
    }
}
