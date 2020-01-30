using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.BaseWebApi.Data.Repositories;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IMatchGroupRepository : IRepository<MatchGroup, int>
    {
        Task<MatchGroup> GetByMatchIdAsync(int matchId);
        Task<MatchGroup> GetByGroupNameAsync(string groupName);
        Task<IList<MatchGroup>> GetAllAsync();
    }
}