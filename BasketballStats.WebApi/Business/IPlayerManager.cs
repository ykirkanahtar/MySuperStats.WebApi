using System.Threading.Tasks;
using BasketballStats.Contracts.Requests;
using BasketballStats.WebApi.Models;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace BasketballStats.WebApi.Business
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