using System.Threading.Tasks;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Models;
using System.Collections.Generic;
using CustomFramework.BaseWebApi.Utils.Business;

namespace MySuperStats.WebApi.Business
{
    public interface ITeamManager : IBusinessManager<Team, TeamRequest, int>
    , IBusinessManagerUpdate<Team, TeamRequest, int>
    {
        Task<IList<Team>> GetAllAsync();
    }
}
