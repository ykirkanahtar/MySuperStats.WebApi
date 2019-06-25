using System;
using System.Net;
using System.Net.Mail;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;
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