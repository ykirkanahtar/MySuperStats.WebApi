using System.Threading.Tasks;
using BasketballStats.Contracts.Requests;
using BasketballStats.WebApi.Models;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace BasketballStats.WebApi.Business
{
    public interface ITeamManager : IBusinessManager
    {
        Task<Team> CreateAsync(TeamRequest request);
        Task<Team> UpdateAsync(int id, TeamRequest request);
        Task DeleteAsync(int id);
        Task<Team> GetByIdAsync(int id);
        Task<CustomEntityList<Team>> GetAllAsync();
    }
}
