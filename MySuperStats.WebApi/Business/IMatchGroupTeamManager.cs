using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Business
{
    public interface IMatchGroupTeamManager : IBusinessManager<MatchGroupTeam, MatchGroupTeamRequest, int>
    {
        Task<ICustomList<MatchGroup>> GetMatchGroupsByTeamIdAsync(int teamId);
        Task<ICustomList<Team>> GetTeamsByMatchGroupIdAsync(int matchGroupId);
    }
}