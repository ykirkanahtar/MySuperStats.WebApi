using System;
using System.Net;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Contracts.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;

namespace MySuperStats.WebUI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly ILogger<ConfirmEmailModel> _logger;
        private readonly AppSettings _appSettings;
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly ILocalizationService _localizer;

        public ConfirmEmailModel(ILogger<ConfirmEmailModel> logger, AppSettings appSettings, IWebApiConnector<ApiResponse> webApiConnector, ILocalizationService localizer)
        {
            _logger = logger;
            _appSettings = appSettings;
            _webApiConnector = webApiConnector;
            _localizer = localizer;
        }

        public async Task<IActionResult> OnGetAsync(string culture, string userId, string code)
        {
            if (userId == null || code == null)
            {
                return NotFound(_localizer.GetValue("Invalid parameter"));
            }

            try
            {
                var apiResponse = await _webApiConnector.GetAsync($"{_appSettings.WebApiUrl}{ApiUrls.ConfirmEmail}/userId/{Convert.ToInt32(userId)}/code/{code}/culture/{culture}", string.Empty);
                if (apiResponse.StatusCode != HttpStatusCode.OK)
                {
                    throw new InvalidOperationException(_localizer.GetValue(String.Format("Error confirming email for user with ID {0}", userId)));
                }

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

            return Page();
        }
    }
}