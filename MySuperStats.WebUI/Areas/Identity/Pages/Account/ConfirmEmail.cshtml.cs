using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Areas.Identity.Data;
using MySuperStats.WebUI.Constants;
using MySuperStats.WebUI.Utils;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly ILogger<ConfirmEmailModel> _logger;
        private readonly AppSettings _appSettings;
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;

        public ConfirmEmailModel(ILogger<ConfirmEmailModel> logger, AppSettings appSettings, IWebApiConnector<ApiResponse> webApiConnector)
        {
            _logger = logger;
            _appSettings = appSettings;
            _webApiConnector = webApiConnector;
        }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return NotFound($"Invalid parameters");
            }

            try
            {
                var apiResponse = await _webApiConnector.GetAsync($"{_appSettings.WebApiUrl}{ApiUrls.ConfirmEmail}/userId/{Convert.ToInt32(userId)}/code/{code}", string.Empty);
                if (apiResponse.StatusCode != HttpStatusCode.OK)
                {
                    throw new InvalidOperationException($"Error confirming email for user with ID '{userId}':");
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