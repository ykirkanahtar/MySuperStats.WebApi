using System;
using System.Net;
using System.Threading.Tasks;
using CustomFramework.BaseWebApi.Contracts.ApiContracts;
using CustomFramework.BaseWebApi.Contracts.Requests;
using CustomFramework.BaseWebApi.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResetPasswordModel : PageModel
    {
        private readonly ILogger<ResetPasswordModel> _logger;
        private readonly AppSettings _appSettings;
        private readonly IWebApiConnector<WebApiResponse> _webApiConnector;
        private readonly ILocalizationService _localizer;

        public ResetPasswordModel(ILogger<ResetPasswordModel> logger, AppSettings appSettings, IWebApiConnector<WebApiResponse> webApiConnector, ILocalizationService localizer)
        {
            _logger = logger;
            _appSettings = appSettings;
            _webApiConnector = webApiConnector;
            _localizer = localizer;
        }

        [BindProperty]
        public ResetPasswordRequest Input { get; set; }

        public IActionResult OnGet(string culture, string code = null)
        {
            if (code == null)
            {
                return BadRequest(_localizer.GetValue("A code must be supplied for password reset."));
            }
            else
            {
                Input = new ResetPasswordRequest
                {
                    Code = code
                };
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(string culture)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var jsonContent = JsonConvert.SerializeObject(Input);

                var apiUrl = $"{_appSettings.WebApiUrl}{ApiUrls.ResetPassword}";
                var apiResponse = await _webApiConnector.PostAsync(apiUrl, jsonContent, culture);

                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    return Redirect($"../ResetPasswordConfirmation/{culture}");
                }
                else
                {
                    ModelState.AddModelError(apiResponse.Message, _localizer.GetValue("AnErrorHasOccured"));
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, _localizer.GetValue("AnErrorHasOccured"));
                return Page();
            }
        }
    }
}