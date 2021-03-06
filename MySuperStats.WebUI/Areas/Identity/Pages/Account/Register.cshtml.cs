using System;
using System.Net;
using System.Threading.Tasks;
using CustomFramework.BaseWebApi.Contracts.ApiContracts;
using CustomFramework.BaseWebApi.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;
        private readonly AppSettings _appSettings;
        private readonly IWebApiConnector<WebApiResponse> _webApiConnector;
        private readonly ILocalizationService _localizer;

        public RegisterModel(ILogger<RegisterModel> logger, AppSettings appSettings, IWebApiConnector<WebApiResponse> webApiConnector, ILocalizationService localizer)
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
                        $"/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { culture = culture, userId = "ReplaceUserIdValue", code = "ReplaceCodeValue" },
                        protocol: Request.Scheme);

                    Input.CallBackUrl = callbackUrl;
                    var jsonContent = JsonConvert.SerializeObject(Input);

                    var apiResponse = await _webApiConnector.PostAsync($"{_appSettings.WebApiUrl}{ApiUrls.Register}", jsonContent, culture);

                    if (apiResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var userResponse = JsonConvert.DeserializeObject<UserResponse>(apiResponse.Result.ToString());

                        return LocalRedirect($"/Identity/Account/RegisterConfirmation/{culture}"); ;
                    }
                    else
                    {
                        ModelState.AddModelError("ModelErrors", _localizer.GetValue(apiResponse.Message));
                        return Page();
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, _localizer.GetValue("AnErrorHasOccured"));
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}