using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.BaseWebApi.Data.Repositories;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IMatchGroupTeamRepository : IRepository<MatchGroupTeam, int>
    {
        Task<IList<MatchGroup>> GetMatchGroupsByTeamIdAsync(int teamId);
        Task<IList<Team>> GetTeamsByMatchGroupIdAsync(int matchGroupId);
        Task<IList<MatchGroupTeam>> GetAllAsync();
    }
}