using System.Threading.Tasks;
using BasketballStats.Contracts.Requests;
using BasketballStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;

namespace BasketballStats.WebApi.Business
{
    public interface ITeamManager : IBusinessManager<Team, TeamRequest, int>
    , IBusinessManagerUpdate<Team, TeamRequest, int>
    {
        Task<ICustomList<Team>> GetAllAsync();
    }
}
