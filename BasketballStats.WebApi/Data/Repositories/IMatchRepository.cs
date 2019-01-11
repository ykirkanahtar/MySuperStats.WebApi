using BasketballStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using System;
using System.Threading.Tasks;
using BasketballStats.Contracts.Responses;

namespace BasketballStats.WebApi.Data.Repositories
{
    public interface IMatchRepository : IRepository<Match, int>
    {
        Task<Match> GetByMatchDateAndOrderAsync(DateTime matchDate, int order);
        Task<ICustomList<Match>> GetAllAsync();
        Task<ICustomList<MatchForMainScreen>> GetMatchForMainScreen();
        Task<MatchDetailStats> GetMatchDetailStats(int matchId);
    }
}