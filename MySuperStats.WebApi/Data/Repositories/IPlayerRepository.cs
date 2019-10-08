using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Data.Repositories;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IPlayerRepository : IRepository<Player, int>
    {
        Task<User> GetUserByIdAsync(int id);
        Task<UserDetailWithBasketballStat> GetByIdWithBasketballStatsAsync(int userId);
        Task<IList<Player>> GetAllByMatchGroupIdAsync(int matchGroupId);
    }
}