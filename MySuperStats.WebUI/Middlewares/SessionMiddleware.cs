using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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
            await _next.Invoke(context);
        }

    }
}