using System.Threading.Tasks;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Helper;

namespace BasketballStats.WebApi.Authorization.Business.Contracts
{
    public interface IUserRoleManager : IBusinessManager
    {
        Task<bool> AddUserToRoleAsync(UserRoleRequest request);
        Task<bool> RemoveUserFromRoleAsync(int id);
        Task<UserRole> GetByIdAsync(int id);
        Task<CustomEntityList<User>> GetUsersByRoleIdAsync(int roleId);
        Task<CustomEntityList<Role>> GetRolesByUserIdAsync(int userId);
    }
}