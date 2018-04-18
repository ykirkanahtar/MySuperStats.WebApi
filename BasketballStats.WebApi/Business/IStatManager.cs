using System.Threading.Tasks;
using BasketballStats.Contracts.Requests;
using BasketballStats.WebApi.Models;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace BasketballStats.WebApi.Business
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