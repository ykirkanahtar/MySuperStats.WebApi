using System;
using System.Net;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;
using MySuperStats.WebUI.Utils;

namespace MySuperStats.WebUI.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        public readonly ISession _session;

        public LogoutModel(IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings, ISession session)
        {
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            _session = session;
        }

        public async Task<IActionResult> OnGetAsync(string culture)
        {
            try
            {
                var postUrl = $"{_appSettings.WebApiUrl}{ApiUrls.Logout}";
                var response = await _webApiConnector.PostAsync(postUrl, string.Empty, culture, SessionUtil.GetToken(_session));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    HttpContext.Session.Clear();
                    return Redirect($"../Identity/Account/Login/{culture}");
                }
                else
                    throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                ViewData.ModelState.AddModelError("ModelErrors", ex.Message);
            }

            return Page();
        }
    }
}
