using MySuperStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using System;
using System.Threading.Tasks;
using MySuperStats.Contracts.Responses;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IMatchRepository : IRepository<Match, int>
    {
        Task<Match> GetByMatchDateAndOrderAsync(DateTime matchDate, int order);
        Task<ICustomList<Match>> GetAllAsync();
        Task<ICustomList<MatchForMainScreen>> GetMatchForMainScreen();
        Task<MatchDetailBasketballStats> GetMatchDetailBasketballStats(int matchId);
    }
}