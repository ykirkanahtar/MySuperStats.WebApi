using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Identity.Contracts.Requests;
using CustomFramework.WebApiUtils.Identity.Contracts.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Areas.Identity.Data;
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

        public RegisterModel(ILogger<RegisterModel> logger, AppSettings appSettings, IWebApiConnector<ApiResponse> webApiConnector)
        {
            _logger = logger;
            _appSettings = appSettings;
            _webApiConnector = webApiConnector;
        }

        [BindProperty]
        public UserRegisterRequest Input { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                try
                {
                    var callbackUrl = Url.Page(
                        $"/Account/ConfirmEmail",
                        pageHandler : null,
                        values : new { userId = "ReplaceUserIdValue", code = "ReplaceCodeValue" },
                        protocol : Request.Scheme);

                    Input.CallBackUrl = callbackUrl;
                    var jsonContent = JsonConvert.SerializeObject(Input);

                    var apiResponse = await _webApiConnector.PostAsync($"{_appSettings.WebApiUrl}{ApiUrls.Register}", jsonContent, string.Empty);

                    if (apiResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var userResponse = JsonConvert.DeserializeObject<UserResponse>(apiResponse.Result.ToString());

                        return LocalRedirect("/Identity/Account/RegisterConfirmation");;
                    }
                    else
                    {
                        ModelState.AddModelError(apiResponse.Message, AppConstants.InvalidLoginAttempt);
                        return Page();
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, AppConstants.InvalidLoginAttempt);
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}