using System;
using System.Threading.Tasks;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Models;
using BasketballStats.WebApi.RequestModels;

namespace BasketballStats.WebApi.Business.Contracts
{
    public interface IStatManager : IBusinessManager
    {
        Task<Stat> CreateAsync(StatRequest request);
        Task<Stat> UpdateAsync(int id, StatRequest request);
        Task DeleteAsync(int id);
        Task<Stat> GetByIdAsync(int id);
        Task<Stat> GetByMatchIdAndPlayerIdAsync(int matchId, int playerId);
        Task<CustomEntityList<Stat>> GetAllByPlayerIdAsync(int playerId);
        Task<CustomEntityList<Stat>> GetAllByPlayerIdAndDateAsync(int playerId, DateTime startDateTime,
            DateTime endDateTime);
        Task<CustomEntityList<Player>> GetAllPlayerByMatchIdAsync(int matchId);
        Task<CustomEntityList<Player>> GetAllPlayerByDateAsync(DateTime startDateTime, DateTime endDateTime);
        Task<CustomEntityList<Match>> GetAllMatchByPlayerIdAsync(int playerId);
        Task<CustomEntityList<Match>> GetAllMatchByPlayerIdAndDateAsync(int playerId, DateTime startDateTime,
            DateTime endDateTime);
    }
}