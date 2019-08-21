using Microsoft.AspNetCore.Builder;

namespace MySuperStats.WebUI.Middlewares
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseSessionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SessionMiddleware>();
        }
    }
}