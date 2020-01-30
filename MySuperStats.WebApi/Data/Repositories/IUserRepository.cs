using MySuperStats.WebApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<Player> GetPlayerByIdAsync(int id);
        Task<Player> GetPlayerByEmailAsync(string email);
        Task<IList<User>> GetAllAsync();
        Task<IList<User>> GetAllByMatchGroupIdAsync(int matchGroupId);
        Task<IList<Role>> GetRolesByUserIdAsync(int userId);

    }
}