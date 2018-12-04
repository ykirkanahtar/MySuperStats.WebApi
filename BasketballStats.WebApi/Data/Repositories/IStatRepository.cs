using BasketballStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Data.Repositories
{
    public interface IStatRepository : IRepository<Stat, int>
    {
        Task<Stat> GetByMatchIdTeamIdAndPlayerId(int matchId, int teamId, int playerId);
        Task<ICustomList<Stat>> GetAllByMatchIdAsync(int matchId);
        Task<ICustomList<Stat>> GetAllByPlayerIdAsync(int playerId);
        Task<ICustomList<Stat>> GetAllAsync();
    }
}