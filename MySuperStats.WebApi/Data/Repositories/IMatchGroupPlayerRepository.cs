using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IMatchGroupPlayerRepository : IRepository<MatchGroupPlayer, int>
    {
        Task<ICustomList<MatchGroup>> GetMatchGroupsByPlayerIdAsync(int playerId);
        Task<ICustomList<Player>> GetPlayersByMatchGroupIdAsync(int matchGroupId);
        Task<ICustomList<MatchGroupPlayer>> GetAllAsync();
    }
}