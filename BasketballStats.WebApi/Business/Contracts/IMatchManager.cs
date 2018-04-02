using BasketballStats.Contracts.Requests;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Models;
using System;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Business.Contracts
{
    public interface IMatchManager : IBusinessManager
    {
        Task<Match> CreateAsync(MatchRequest request);
        Task<Match> UpdateAsync(int id, MatchRequest request);
        Task DeleteAsync(int id);
        Task<Match> GetByIdAsync(int id);
        Task<CustomEntityList<Match>> GetAllAsync();
    }
}
