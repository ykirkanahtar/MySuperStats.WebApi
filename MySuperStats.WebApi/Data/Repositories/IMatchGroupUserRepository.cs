using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IMatchGroupUserRepository : IRepository<MatchGroupUser, int>
    {
        Task<IList<MatchGroup>> GetMatchGroupsByUserIdAsync(int userId);
        Task<IList<User>> GetUsersByMatchGroupIdAsync(int matchGroupId);
        Task<bool> UserIsInMatchGroupAsync(int matchGroupId, int userId);
        Task<IList<MatchGroupUser>> GetAllAsync();
    }
}