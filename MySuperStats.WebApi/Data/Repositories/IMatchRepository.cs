using MySuperStats.WebApi.Models;
using CustomFramework.Data.Repositories;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IMatchRepository : IRepository<Match, int>
    {
        Task<Match> GetByMatchDateAndOrderAsync(DateTime matchDate, int order);
        Task<IList<Match>> GetAllByMatchGroupIdAsync(int matchGroupId);
        Task<IList<Match>> GetMatchForMainScreen(int matchGroupId);
        Task<Match> GetMatchDetailBasketballStats(int matchId);
        Task<Match> GetMatchDetailFootballStats(int matchId);
    }
}