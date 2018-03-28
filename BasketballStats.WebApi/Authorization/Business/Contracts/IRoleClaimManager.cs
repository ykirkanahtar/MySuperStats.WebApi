using System.Collections.Generic;
using System.Threading.Tasks;
using BasketballStats.WebApi.Authorization.Enums;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Helper;

namespace BasketballStats.WebApi.Authorization.Business.Contracts
{
    public interface IRoleClaimManager : IBusinessManager
    {
        Task<bool> AddRoleToClaimAsync(RoleClaimRequest request);
        Task<bool> RemoveRoleFromClaimAsync(int id);
        Task<RoleClaim> GetByIdAsync(int id);
        Task<bool> RolesAreAuthorizedForClaimAsync(IList<Role> roles, int claimId);
        Task<CustomEntityList<Role>> GetRolesByClaimIdAsync(int claimId);
        Task<CustomEntityList<Claim>> GetClaimsByRoleIdAsync(int roleId);
    }
}