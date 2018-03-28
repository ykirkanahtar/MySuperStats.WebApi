using System.Threading.Tasks;
using BasketballStats.WebApi.Authorization.Enums;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Helper;

namespace BasketballStats.WebApi.Authorization.Business.Contracts
{
    public interface IUserClaimManager : IBusinessManager
    {
        Task<bool> AddUserToClaimAsync(UserClaimRequest request);
        Task<bool> RemoveUserFromClaimAsync(int userClaimId);
        Task<UserClaim> GetByIdAsync(int id);
        Task<bool> UserIsAuthorizedForClaimAsync(int userId, int claimId);
        Task<CustomEntityList<User>> GetUsersByClaimIdAsync(int claimId);
        Task<CustomEntityList<Claim>> GetClaimsByUserIdAsync(int userId);
    }
}