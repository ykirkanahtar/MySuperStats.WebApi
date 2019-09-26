using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MySuperStats.WebUI.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var connectionTypeString = context.Request.IsHttps == true ? "https" : "http";
            var cultureInfo = System.Globalization.CultureInfo.CurrentCulture.Name;

            if (ex.Message == "UserNotLoggedIn")
            {
                var redirectUrl = $"{connectionTypeString}://{context.Request.Host}/Identity/Account/Login/{cultureInfo}";
                context.Response.Redirect($"{redirectUrl}");
            }
            else
                await _next(context);
        }
    }
}