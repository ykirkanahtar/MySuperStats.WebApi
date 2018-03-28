using BasketballStats.WebApi.Authorization.Models;

namespace BasketballStats.WebApi.Contracts
{
    public interface IApiRequest
    {
        User User { get; set; }
        ClientApplication ClientApplication { get; set; }
    }
}