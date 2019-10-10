using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Contracts.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;
using MySuperStats.WebUI.Utils;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
            private readonly ILogger<ForgotPasswordModel> _logger;
            private readonly AppSettings _appSettings;
            private readonly IWebApiConnector<ApiResponse> _webApiConnector;
            private readonly ILocalizationService _localizer;

        public ForgotPasswordModel(ILogger<ForgotPasswordModel> logger, AppSettings appSettings, IWebApiConnector<ApiResponse> webApiConnector, ILocalizationService localizer)
        {
            _logger = logger;
            _appSettings = appSettings;
            _webApiConnector = webApiConnector;
            _localizer = localizer;
        }

        [BindProperty]
        public PasswordRecoveryRequest Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync(string culture)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var callbackUrl = Url.Page(
                        $"/Account/ResetPassword/{culture}",
                        pageHandler : null,
                        values : new { code = "ReplaceCodeValue" },
                        protocol : Request.Scheme);

                    Input.CallBackUrl = callbackUrl;
                    var jsonContent = JsonConvert.SerializeObject(Input);

                    var apiResponse = await _webApiConnector.PostAsync($"{_appSettings.WebApiUrl}{ApiUrls.ForgotPassword}", jsonContent, string.Empty);

                    if (apiResponse.StatusCode == HttpStatusCode.OK)
                    {
                        return RedirectToPage($"./ForgotPasswordConfirmation/{culture}");
                    }
                    else
                    {
                        ModelState.AddModelError(apiResponse.Message, _localizer.GetValue("Invalid login attempt"));
                        return Page();
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, _localizer.GetValue("Invalid login attempt"));
                    return Page();
                }
            }

            return Page();
        }
    }
}