using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IFootballStatRepository : IRepository<FootballStat, int>
    {
        Task<FootballStat> GetByMatchIdTeamIdAndPlayerId(int matchId, int teamId, int playerId);
        Task<decimal> GetTeamScoreByMatchIdAndTeamId(int matchId, int teamId);
        Task<ICustomList<FootballStat>> GetAllByMatchIdAsync(int matchId);
        Task<ICustomList<FootballStat>> GetAllByPlayerIdAsync(int playerId);
        Task<ICustomList<FootballStat>> GetAllAsync();

    }
}