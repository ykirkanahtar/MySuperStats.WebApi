using System.Threading.Tasks;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Contracts;

namespace BasketballStats.WebApi.Authorization.Business.Contracts
{
    public interface IClientApplicationUtilManager : IBusinessManager
    {
        Task<ClientApplicationUtil> CreateAsync(ClientApplicationUtilRequest request);

        Task<ClientApplicationUtil> UpdateSpecialValueAsync(int id, string specialValue);

        Task DeleteAsync(int id);

        Task<ClientApplicationUtil> GetByIdAsync(int id);

        Task<ClientApplicationUtil> GetByClientApplicationIdAsync(int clientApplicationId);
    }
}