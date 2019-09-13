using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace MySuperStats.WebUI.Middlewares
{
    public class SessionMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var pathValue = context.Request.Path.Value;
            if (pathValue.Contains("Error"))
            {
                await _next.Invoke(context);
            }
            else
            {
                if (pathValue.Contains("StatisticEntry") != true)
                {
                    context.Session.Remove("StatisticEntryForBasketballMatch");
                }

                await _next.Invoke(context);
            }
        }

    }
}