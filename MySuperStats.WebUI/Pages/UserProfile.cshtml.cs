
using System;
using System.Net;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;
using MySuperStats.WebUI.Utils;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Pages
{
    public class UserProfileModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        public readonly ISession _session;
        public UserResponse UserInfo { get; set; }


        public UserProfileModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            UserInfo = new UserResponse();
        }


        public async Task OnGet(string culture)
        {
            var user = SessionUtil.GetLoggedUser(_session);
            var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetUserById, user.Id)}";
            var response = await _webApiConnector.GetAsync(getUrl, culture, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                UserInfo = JsonConvert.DeserializeObject<UserResponse>(response.Result.ToString());
            }
            else
                throw new Exception(response.Message);
        }

        public IActionResult OnPostUpdateUserProfile(string culture)
        {
            return Redirect($"../{culture}/UpdateUserProfile");
        }
    }
}
