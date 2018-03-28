using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Contracts;
using System.Threading.Tasks;
using BasketballStats.WebApi.Authorization.Request;

namespace BasketballStats.WebApi.Authorization.Business.Contracts
{
    public interface IClientApplicationManager : IBusinessManager
    {
        Task<ClientApplication> CreateAsync(ClientApplicationRequest request);

        Task<ClientApplication> UpdateClientApplicationAsync(int id, ClientApplicationUpdateRequest request);

        Task<ClientApplication> UpdateClientApplicationPasswordAsync(int id, string clientApplicationPassword);

        Task DeleteAsync(int id);

        Task<ClientApplication> GetByIdAsync(int id);

        Task<ClientApplication> GetByClientApplicationCodeAsync(string code);

        Task<ClientApplication> LoginAsync(string code, string password);
    }
}