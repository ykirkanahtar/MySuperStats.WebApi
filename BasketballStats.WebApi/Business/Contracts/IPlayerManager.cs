using BasketballStats.Contracts.Requests;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Models;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Business.Contracts
{
    public interface IPlayerManager : IBusinessManager
    {
        Task<Player> CreateAsync(PlayerRequest request);
        Task<Player> UpdateAsync(int id, PlayerRequest request);
        Task DeleteAsync(int id);
        Task<Player> GetByIdAsync(int id);
        Task<CustomEntityList<Player>> GetAllAsync();
    }
}