using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.BaseWebApi.Utils.Business;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Business
{
    public interface IMatchGroupUserManager : IBusinessManager<MatchGroupUser, MatchGroupPlayerRequest, int>
    {
        Task<MatchGroupUser> GetByMatchGroupIdAndUserIdAsync(int matchGroupId, int userId);
        Task<MatchGroupUser> UpdateRoleAsync(MatchGroupUserRequest request);
        Task<IList<MatchGroup>> GetMatchGroupsByUserIdAsync(int userId);
        Task<IList<User>> GetUsersByMatchGroupIdAsync(int matchGroupId);
        Task<IList<MatchGroupUser>> GetAllUsersByMatchGroupIdAsync(int matchGroupId);
    }
}