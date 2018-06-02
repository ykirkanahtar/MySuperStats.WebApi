using System;
using System.Threading.Tasks;
using BasketballStats.WebApi.Models;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;

namespace BasketballStats.WebApi.Data.Repositories
{
    public interface IMatchRepository : IRepository<Match, int>
    {
        Task<Match> GetByMatchDateAndOrderAsync(DateTime matchDate, int order);
        Task<ICustomList<Match>> GetAllAsync();
    }
}