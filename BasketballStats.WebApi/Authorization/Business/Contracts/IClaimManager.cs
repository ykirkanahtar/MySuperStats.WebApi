using BasketballStats.WebApi.Authorization.Enums;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Contracts;
using System.Threading.Tasks;
using BasketballStats.WebApi.Helper;

namespace BasketballStats.WebApi.Authorization.Business.Contracts
{
    public interface IClaimManager : IBusinessManager
    {
        Task<Claim> CreateAsync(ClaimRequest request);
        Task<Claim> UpdateAsync(int id, ClaimRequest request);
        Task DeleteAsync(int id);
        Task<Claim> GetByIdAsync(int id);
        Task<Claim> GetByCustomClaimAsync(CustomClaim customClaim);
        Task<CustomEntityList<Claim>> GetAllAsync();
    }
}