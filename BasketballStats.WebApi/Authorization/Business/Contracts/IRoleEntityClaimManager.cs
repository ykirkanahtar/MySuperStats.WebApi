using System.Collections.Generic;
using System.Threading.Tasks;
using BasketballStats.WebApi.Authorization.Enums;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Helper;

namespace BasketballStats.WebApi.Authorization.Business.Contracts
{
    public interface IRoleEntityClaimManager : IBusinessManager
    {
        Task<RoleEntityClaim> CreateAsync(RoleEntityClaimRequest request);
        Task<RoleEntityClaim> UpdateAsync(int id, EntityClaimRequest request);
        Task DeleteAsync(int id);
        Task<RoleEntityClaim> GetByIdAsync(int id);
        Task<bool> RolesAreAuthorizedForClaimAsync(IList<Role> roles, Entity entity, Crud crud);
        Task<CustomEntityList<RoleEntityClaim>> GetAllByEntityAsync(Entity entity);
        Task<CustomEntityList<RoleEntityClaim>> GetAllByRoleIdAsync(int roleId);
    }
}