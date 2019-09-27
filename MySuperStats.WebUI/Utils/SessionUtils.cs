using System.Security.Authentication;
using System.Text;
using Microsoft.AspNetCore.Http;
using MySuperStats.Contracts.Responses;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Utils
{
    public static class SessionUtil
    {
        public static string GetToken(ISession session)
        {
            var tokenInBytes = session.Get("UserToken");
            if (tokenInBytes == null) throw new AuthenticationException("UserNotLoggedIn");
            return Encoding.UTF8.GetString(tokenInBytes);
        }

        public static UserResponse GetLoggedUser(ISession session)
        {
            var userInBytes = session.Get("User");
            if (userInBytes == null) throw new AuthenticationException("UserNotLoggedIn");
            var user = JsonConvert.DeserializeObject<UserResponse>(Encoding.UTF8.GetString(userInBytes));
            return user;
        }
    }
}