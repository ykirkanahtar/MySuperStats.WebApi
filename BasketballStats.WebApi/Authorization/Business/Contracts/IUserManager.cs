using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Helper;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Authorization.Business.Contracts
{
    public interface IUserManager : IBusinessManager
    {
        Task<User> CreateAsync(UserRequest request);
        Task<User> UpdateUserNameAsync(int id, string userName);
        Task<User> UpdatePasswordAsync(int id, string password);
        Task<User> UpdateEmailAsync(int id, string email);
        Task DeleteAsync(int id);
        Task<User> LoginAsync(string userName, string password);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByUserNameAsync(string userName);
        Task<User> GetByEmailAsync(string email);
        Task<CustomEntityList<User>> GetAllAsync();
    }
}