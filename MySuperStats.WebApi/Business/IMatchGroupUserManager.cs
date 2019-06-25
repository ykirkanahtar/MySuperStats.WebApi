using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Business
{
    public interface IMatchGroupUserManager : IBusinessManager<MatchGroupUser, MatchGroupUserRequest, int>
    {
        Task<IList<MatchGroup>> GetMatchGroupsByUserIdAsync(int userId);
        Task<IList<User>> GetUsersByMatchGroupIdAsync(int matchGroupId);
    }
}