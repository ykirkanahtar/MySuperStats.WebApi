using System.Threading.Tasks;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Contracts;

namespace BasketballStats.WebApi.Authorization.Business.Contracts
{
    public interface IUserUtilManager : IBusinessManager
    {
        Task<UserUtil> CreateAsync(UserUtilRequest request);

        Task<UserUtil> UpdateSpecialValueAsync(int id, string specialValue);

        Task DeleteAsync(int id);

        Task<UserUtil> GetByIdAsync(int id);

        Task<UserUtil> GetByUserIdAsync(int userId);
    }
}