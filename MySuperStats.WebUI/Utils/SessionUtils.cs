using System.Security.Authentication;
using Microsoft.AspNetCore.Http;
using MySuperStats.Contracts.Responses;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Utils
{
    public static class SessionUtil
    {
        public static string GetToken(ISession session)
        {
            var token = session.GetString("UserToken");
            if (string.IsNullOrEmpty(token)) throw new AuthenticationException("UserNotLoggedIn");
            return token;
        }

        public static UserResponse GetLoggedUser(ISession session)
        {
            var userJson = session.GetString("User");
            if (string.IsNullOrEmpty(userJson)) throw new AuthenticationException("UserNotLoggedIn");
            var user = JsonConvert.DeserializeObject<UserResponse>(userJson);
            return user;
        }
    }
}