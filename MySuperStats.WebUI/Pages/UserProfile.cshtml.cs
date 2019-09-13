
using System;
using System.Collections.Generic;
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
        public MatchGroupResponse MatchGroupResponse { get; set; }
        public List<UserResponse> Players { get; set; }


        public UserProfileModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            MatchGroupResponse = new MatchGroupResponse();
        }


        public async Task OnGet()
        {
            await GetMatchGroupDetailAsync();
            await GetPlayersOnMatchGroupAsync();
        }

        private async Task GetMatchGroupDetailAsync()
        {
            var getUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetMatchGroupById}{1}";
            var response = await _webApiConnector.GetAsync(getUrl, SessionUtil.GetToken(_session));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                MatchGroupResponse = JsonConvert.DeserializeObject<MatchGroupResponse>(response.Result.ToString());
            }
            else
                throw new Exception(response.Message);
        }

        private async Task GetPlayersOnMatchGroupAsync()
        {
            var getUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetAllUsersByMatchGroupId}{1}";
            var response = await _webApiConnector.GetAsync(getUrl, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Players = JsonConvert.DeserializeObject<List<UserResponse>>(response.Result.ToString());
            }
            else
                throw new Exception(response.Message);
        }

        public IActionResult OnPostChangeGroupName()
        {
            return Redirect($"../ChangeMatchGroupName/{1}");
        }

        public IActionResult OnPostAddUserToMatchGroup()
        {
            return Redirect($"../AddUserToMatchGroup/{1}");
        }
    }
}
