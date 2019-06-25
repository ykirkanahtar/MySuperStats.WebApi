using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Areas.Identity.Data;
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

        public ForgotPasswordModel(ILogger<ForgotPasswordModel> logger, AppSettings appSettings, IWebApiConnector<ApiResponse> webApiConnector)
        {
            _logger = logger;
            _appSettings = appSettings;
            _webApiConnector = webApiConnector;
        }

        [BindProperty]
        public PasswordRecoveryRequest Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var callbackUrl = Url.Page(
                        "/Account/ResetPassword",
                        pageHandler : null,
                        values : new { code = "ReplaceCodeValue" },
                        protocol : Request.Scheme);

                    Input.CallBackUrl = callbackUrl;
                    var jsonContent = JsonConvert.SerializeObject(Input);

                    var apiResponse = await _webApiConnector.PostAsync($"{_appSettings.WebApiUrl}{ApiUrls.ForgotPassword}", jsonContent, string.Empty);

                    if (apiResponse.StatusCode == HttpStatusCode.OK)
                    {
                        return RedirectToPage("./ForgotPasswordConfirmation");
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

            return Page();
        }
    }
}