using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Contracts;

namespace BasketballStats.WebApi
{
    public class ApiRequest : IApiRequest
    {
        public ApiRequest(User user, ClientApplication clientApplication)
        {
            User = user;
            ClientApplication = clientApplication;
        }

        public User User { get; set; }

        public ClientApplication ClientApplication { get; set; }

    }
}