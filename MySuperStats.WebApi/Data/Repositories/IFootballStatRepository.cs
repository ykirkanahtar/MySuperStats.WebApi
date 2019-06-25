using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IFootballStatRepository : IRepository<FootballStat, int>
    {
        Task<FootballStat> GetByMatchIdTeamIdAndUserId(int matchId, int teamId, int userId);
        Task<decimal> GetTeamScoreByMatchIdAndTeamId(int matchId, int teamId);
        Task<IList<FootballStat>> GetAllByMatchIdAsync(int matchId);
        Task<IList<FootballStat>> GetAllByUserIdAsync(int userId);
        Task<IList<FootballStat>> GetAllAsync();

    }
}