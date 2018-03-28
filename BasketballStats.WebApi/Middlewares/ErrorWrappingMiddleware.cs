using System;
using System.Net;
using System.Threading.Tasks;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Exceptions;
using BasketballStats.WebApi.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BasketballStats.WebApi.Middlewares
{
    public class ErrorWrappingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorWrappingMiddleware> _logger;
        private readonly ILocalizationService _localizationService;

        public ErrorWrappingMiddleware(RequestDelegate next, ILogger<ErrorWrappingMiddleware> logger, ILocalizationService localizationService)
        {
            _next = next;
            _localizationService = localizationService;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            Exception exception = new Exception();

            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                exception = ex;

                context.Response.StatusCode = (int)ex.ExceptionToStatusCode();
            }

            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";

                var apiResponse = new ApiResponse(_localizationService, _logger).Error((HttpStatusCode)context.Response.StatusCode, exception);

                var json = JsonConvert.SerializeObject(apiResponse, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                await context.Response.WriteAsync(json);
            }
        }
    }
}