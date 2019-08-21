using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MySuperStats.WebUI.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public ErrorModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string ExceptionMessage { get; set; }
        public string PreviousPageUrl { get; set; }

        public void OnGet()
        {
            PreviousPageUrl = _httpContextAccessor.HttpContext.Request.Headers["Referer"].ToString();

            RequestId = Activity.Current?.Id ?? _httpContextAccessor.HttpContext.TraceIdentifier;

            var exceptionHandlerPathFeature = _httpContextAccessor.HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ExceptionMessage = exceptionHandlerPathFeature.Error.Message;

        }
    }
}
