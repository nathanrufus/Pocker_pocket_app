// IUserService.cs
using PokerPocket.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokerPocket.Services
{
    public interface IUserService
    {
        Task<User> Register(User user, string password);
        Task<User> Authenticate(string email, string password);
        Task<IEnumerable<User>> GetAllUsers();
    }
}