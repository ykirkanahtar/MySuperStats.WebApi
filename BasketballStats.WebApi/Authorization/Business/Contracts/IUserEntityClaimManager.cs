using System.Threading.Tasks;
using BasketballStats.WebApi.Authorization.Enums;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Helper;

namespace BasketballStats.WebApi.Authorization.Business.Contracts
{
    public interface IUserEntityClaimManager : IBusinessManager
    {
        Task<UserEntityClaim> CreateAsync(UserEntityClaimRequest request);
        Task<UserEntityClaim> UpdateAsync(int id, EntityClaimRequest request);
        Task DeleteAsync(int id);
        Task<UserEntityClaim> GetByIdAsync(int id);
        Task<bool> UserIsAuthorizedForEntityClaimAsync(int userId, Entity entity, Crud crud);

        Task<CustomEntityList<UserEntityClaim>> GetAllByEntityAsync(Entity entity);
        Task<CustomEntityList<UserEntityClaim>> GetAllByUserIdAsync(int userId);
    }
}