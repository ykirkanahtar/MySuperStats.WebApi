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
using MySuperStats.Contracts.Responses;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;
using MySuperStats.WebUI.Utils;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;
        private readonly AppSettings _appSettings;
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly ILocalizationService _localizer;

        public RegisterModel(ILogger<RegisterModel> logger, AppSettings appSettings, IWebApiConnector<ApiResponse> webApiConnector, ILocalizationService localizer)
        {
            _logger = logger;
            _appSettings = appSettings;
            _webApiConnector = webApiConnector;
            _localizer = localizer;
        }

        [BindProperty]
        public UserRegisterRequest Input { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string culture, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content($"~/{culture}");

            if (ModelState.IsValid)
            {
                try
                {
                    var callbackUrl = Url.Page(
                        $"/Account/ConfirmEmail/{culture}",
                        pageHandler: null,
                        values: new { userId = "ReplaceUserIdValue", code = "ReplaceCodeValue" },
                        protocol: Request.Scheme);

                    Input.CallBackUrl = callbackUrl;
                    var jsonContent = JsonConvert.SerializeObject(Input);

                    var apiResponse = await _webApiConnector.PostAsync($"{_appSettings.WebApiUrl}{ApiUrls.Register}", jsonContent, string.Empty);

                    if (apiResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var userResponse = JsonConvert.DeserializeObject<UserResponse>(apiResponse.Result.ToString());

                        return LocalRedirect("/Identity/Account/RegisterConfirmation/{culture}"); ;
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

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}