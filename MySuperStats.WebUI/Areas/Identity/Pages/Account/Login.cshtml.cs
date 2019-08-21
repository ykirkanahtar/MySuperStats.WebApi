using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Identity.Contracts.Requests;
using CustomFramework.WebApiUtils.Identity.Contracts.Responses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly AppSettings _appSettings;
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly ISession _session;

        public LoginModel(ISession session, ILogger<LoginModel> logger, AppSettings appSettings, IWebApiConnector<ApiResponse> webApiConnector)
        {
            _session = session;
            _logger = logger;
            _appSettings = appSettings;
            _webApiConnector = webApiConnector;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            public InputModel()
            {
                Login = new Login();
                Login.ClientApplicationCode = "web"; //TODO burayı appsettings'ten almak lazım
                Login.ClientApplicationPassword = "1212";
            }

            public Login Login { get; set; }

            [Display(Name = AppConstants.RememberMe)]
            public bool RememberMe { get; set; }
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                try
                {
                    var jsonContent = JsonConvert.SerializeObject(Input.Login);

                    var apiResponse = await _webApiConnector.PostAsync($"{_appSettings.WebApiUrl}{ApiUrls.Login}", jsonContent, string.Empty);

                    if (apiResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(apiResponse.Result.ToString());

                        _session.Set("UserToken", Encoding.UTF8.GetBytes(tokenResponse.Token));
                        _session.Set("TokenExpireDate", Encoding.UTF8.GetBytes(tokenResponse.ExpireUtcDateTime.ToLongDateString()));
                        _session.Set("UserId", BitConverter.GetBytes(tokenResponse.UserId));

                        var getUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetUserById}{tokenResponse.UserId}";
                        var response = await _webApiConnector.GetAsync(getUrl, tokenResponse.Token);
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            _session.Set("User", Encoding.UTF8.GetBytes(response.Result.ToString()));
                        }
                        else
                            throw new Exception(response.Message);

                        _logger.LogInformation("User logged in.");
                        return LocalRedirect(returnUrl);
                    }

                    // if (result.IsLockedOut)
                    // {
                    //     _logger.LogWarning(AppConstants.UserAccountLockedOut);
                    //     return RedirectToPage("./Lockout");
                    // }
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