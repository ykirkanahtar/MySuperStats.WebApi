using System.Threading.Tasks;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;

namespace MySuperStats.WebApi.Business
{
    public interface ITeamManager : IBusinessManager<Team, TeamRequest, int>
    , IBusinessManagerUpdate<Team, TeamRequest, int>
    {
        Task<ICustomList<Team>> GetAllAsync();
    }
}
