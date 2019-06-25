using System.Threading.Tasks;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;
using System.Collections.Generic;

namespace MySuperStats.WebApi.Business
{
    public interface ITeamManager : IBusinessManager<Team, TeamRequest, int>
    , IBusinessManagerUpdate<Team, TeamRequest, int>
    {
        Task<IList<Team>> GetAllAsync();
    }
}
