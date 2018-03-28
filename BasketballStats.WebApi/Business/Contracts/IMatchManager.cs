using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Models;
using BasketballStats.WebApi.RequestModels;

namespace BasketballStats.WebApi.Business.Contracts
{
    public interface IMatchManager : IBusinessManager
    {
        Task<Match> CreateAsync(MatchRequest request);
        Task<Match> UpdateAsync(int id, MatchRequest request);
        Task DeleteAsync(int id);
        Task<Match> GetByIdAsync(int id);
        Task<CustomEntityList<Match>> GetAllByDateAsync(DateTime startDateTime, DateTime endDateTime);
        Task<CustomEntityList<Match>> GetAllAsync();
    }
}
