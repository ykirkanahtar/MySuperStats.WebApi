using System.Threading.Tasks;
using BasketballStats.WebApi.Models;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;

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