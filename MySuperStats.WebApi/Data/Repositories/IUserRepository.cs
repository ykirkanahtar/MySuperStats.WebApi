using MySuperStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
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
        Task<IList<string>> GetRolesAsync(int userId, int matchGroupId);
    }
}