using MySuperStats.WebApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<IList<User>> GetAllAsync();
        Task<User> GetByIdWithBasketballStatsAsync(int userId);
        Task<IList<User>> GetAllByMatchGroupIdAsync(int matchGroupId);
        //Task<IList<Role>> GetRolesAsync(int userId, int matchGroupId);
        // void AddUserToRole(UserRole request);
        // void RemoveUserFromRole(UserRole request);
        // Task<IList<UserRole>> GetUserRolesByMatchGroupIdAsync(int matchGroupId);
    }
}