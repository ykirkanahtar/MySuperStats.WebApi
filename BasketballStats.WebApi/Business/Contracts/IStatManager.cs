using BasketballStats.Contracts.Requests;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Models;
using System;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Business.Contracts
{
    public interface IStatManager : IBusinessManager
    {
        Task<Stat> CreateAsync(StatRequest request);

        Task<Stat> UpdateAsync(int id, StatRequest request);

        Task DeleteAsync(int id);

        Task<Stat> GetByIdAsync(int id);

        Task<CustomEntityList<Stat>> GetAllByMatchIdAsync(int matchId);
        Task<CustomEntityList<Stat>> GetAllByPlayerIdAsync(int playerId);
        Task<CustomEntityList<Stat>> GetAllAsync();
    }
}