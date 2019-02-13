using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IMatchGroupTeamRepository : IRepository<MatchGroupTeam, int>
    {
        Task<ICustomList<MatchGroup>> GetMatchGroupsByTeamIdAsync(int teamId);
        Task<ICustomList<Team>> GetTeamsByMatchGroupIdAsync(int matchGroupId);
        Task<ICustomList<MatchGroupTeam>> GetAllAsync();
    }
}