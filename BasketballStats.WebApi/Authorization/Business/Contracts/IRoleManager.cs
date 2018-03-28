using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Helper;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Authorization.Business.Contracts
{
    public interface IRoleManager : IBusinessManager
    {
        Task<Role> CreateAsync(RoleRequest request);
        Task<Role> UpdateAsync(int id, RoleRequest request);
        Task DeleteAsync(int id);
        Task<Role> GetByIdAsync(int id);
        Task<Role> GetByNameAsync(string name);
        Task<CustomEntityList<Role>> GetAllAsync();
    }
}