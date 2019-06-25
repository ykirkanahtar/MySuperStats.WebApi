using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Identity.Contracts.Requests;
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
    public class ResetPasswordModel : PageModel
    {
        private readonly ILogger<ResetPasswordModel> _logger;
        private readonly AppSettings _appSettings;
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;

        public ResetPasswordModel(ILogger<ResetPasswordModel> logger, AppSettings appSettings, IWebApiConnector<ApiResponse> webApiConnector)
        {
            _logger = logger;
            _appSettings = appSettings;
            _webApiConnector = webApiConnector;
        }

        [BindProperty]
        public ResetPasswordRequest Input { get; set; }

        public IActionResult OnGet(string code = null)
        {
            if (code == null)
            {
                return BadRequest("A code must be supplied for password reset.");
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var jsonContent = JsonConvert.SerializeObject(Input);

                var apiResponse = await _webApiConnector.PostAsync($"{_appSettings.WebApiUrl}{ApiUrls.ResetPassword}", jsonContent, string.Empty);

                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    return RedirectToPage("./ResetPasswordConfirmation");
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
    }
}