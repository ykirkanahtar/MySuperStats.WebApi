using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MySuperStats.WebUI.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ISession _session;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
            //_session = session;
        }

        public async Task Invoke(HttpContext context, ISession session)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                HandleException(context, ex, session);
            }
        }

        private void HandleException(HttpContext context, Exception ex, ISession session)
        {
            var connectionTypeString = context.Request.IsHttps == true ? "https" : "http";
            var cultureInfo = System.Globalization.CultureInfo.CurrentCulture.Name;

            if (ex.Message == "UserNotLoggedIn")
            {
                var redirectUrl = $"{connectionTypeString}://{context.Request.Host}/Identity/Account/Login/{cultureInfo}";
                context.Response.Redirect($"{redirectUrl}");
            }
            else
            {
                //session.Set("LastException", ex.ObjectToByteArray());
                var redirectUrl = $"{connectionTypeString}://{context.Request.Host}/{cultureInfo}/Error";
                context.Response.Redirect($"{redirectUrl}");
            }
        }
    }
}