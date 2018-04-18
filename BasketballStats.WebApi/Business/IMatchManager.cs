using System.Threading.Tasks;
using BasketballStats.Contracts.Requests;
using BasketballStats.WebApi.Models;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace BasketballStats.WebApi.Business
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
