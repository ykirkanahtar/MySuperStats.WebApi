using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.BaseWebApi.Data.Repositories;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IMatchGroupUserRepository : IRepository<MatchGroupUser, int>
    {
        Task<IList<MatchGroupUser>> GetAllUsersByMatchGroupIdAsync(int matchGroupId);
        Task<IList<MatchGroup>> GetMatchGroupsByUserIdAsync(int userId);
        Task<IList<User>> GetUsersByMatchGroupIdAsync(int matchGroupId);
        Task<bool> UserIsInMatchGroupAsync(int matchGroupId, int userId);
        Task<bool> PlayerIsInMatchGroupAsync(int matchGroupId, int playerId);

        Task<MatchGroupUser> GetByMatchGroupIdAndUserIdAsync(int matchGroupId, int userId);
        Task<IList<MatchGroupUser>> GetAllAsync();
    }
}