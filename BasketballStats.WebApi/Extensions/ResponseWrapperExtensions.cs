using BasketballStats.WebApi.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace BasketballStats.WebApi.Extensions
{
    public static class ResponseWrapperExtensions
    {
        public static IApplicationBuilder UseErrorWrappingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorWrappingMiddleware>();
        }
    }
}