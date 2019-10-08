using System.Diagnostics;
using CustomFramework.WebApiUtils.Contracts.Resources;
using CustomFramework.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace MySuperStats.WebUI.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILocalizationService _localizer;
        private readonly ISession _session;

        public ErrorModel(IHttpContextAccessor httpContextAccessor, ILocalizationService localizer, ISession session)
        {
            _httpContextAccessor = httpContextAccessor;
            _localizer = localizer;
            _session = session;
        }
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string ExceptionMessage { get; set; }
        public string PreviousPageUrl { get; set; }

        public void OnGet()
        {
            PreviousPageUrl = _httpContextAccessor.HttpContext.Request.Headers["Referer"].ToString();

            RequestId = Activity.Current?.Id ?? _httpContextAccessor.HttpContext.TraceIdentifier;

            var lastExceptionObj = _session.Get("LastException");
            var lastException = (Exception)lastExceptionObj.ByteArrayToObject();
            ExceptionMessage = _localizer.GetValue(lastException.Message);
            
            //var exceptionHandlerPathFeature = _httpContextAccessor.HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            //ExceptionMessage = _localizer.GetValue(exceptionHandlerPathFeature.Error.Message);
        }
    }
}
