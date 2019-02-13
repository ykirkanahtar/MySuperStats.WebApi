using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IMatchGroupRepository : IRepository<MatchGroup, int>
    {
        Task<MatchGroup> GetByGroupNameAsync(string groupName);
        Task<ICustomList<MatchGroup>> GetAllAsync();
    }
}