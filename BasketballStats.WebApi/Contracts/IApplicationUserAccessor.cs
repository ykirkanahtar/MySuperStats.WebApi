using BasketballStats.WebApi.Authorization.Models;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Contracts
{
    public interface IApiRequestAccessor
    {
        T GetApiRequest<T>();
    }
}