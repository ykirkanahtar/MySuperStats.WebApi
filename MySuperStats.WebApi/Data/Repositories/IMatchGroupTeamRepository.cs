using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
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