using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Models;
using BasketballStats.WebApi.RequestModels;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Business.Contracts
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
