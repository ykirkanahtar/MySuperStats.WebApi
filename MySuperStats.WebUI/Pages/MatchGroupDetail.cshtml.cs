
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;
using MySuperStats.WebUI.Utils;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Pages
{
    public class MatchGroupDetailModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        private readonly ISession _session;
        private readonly IPermissionChecker _permissionChecker;
        public MatchGroupResponse MatchGroupResponse { get; set; }
        public List<UserResponse> Players { get; set; }

        [BindProperty]
        public bool HasPermissionForChangeGroupName { get; set; }

        [BindProperty]
        public bool HasPermissionForAddUser { get; set; }

        public MatchGroupDetailModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings, IPermissionChecker permissionChecker)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            _permissionChecker = permissionChecker;

            MatchGroupResponse = new MatchGroupResponse();
        }


        public async Task OnGet(int id)
        {
            var user = SessionUtil.GetLoggedUser(_session);

            HasPermissionForChangeGroupName =
                 await _permissionChecker.HasPermissionAsync(id, user.Id, PermissionEnum.UpdateMatchGroup);

            HasPermissionForAddUser =
                 await _permissionChecker.HasPermissionAsync(id, user.Id, PermissionEnum.CreateMatchGroupUser);

            await GetMatchGroupDetailAsync(id);
            await GetPlayersOnMatchGroupAsync(id);
        }

        private async Task GetMatchGroupDetailAsync(int id)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetMatchGroupById}{id}";
            var response = await _webApiConnector.GetAsync(getUrl, SessionUtil.GetToken(_session));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                MatchGroupResponse = JsonConvert.DeserializeObject<MatchGroupResponse>(response.Result.ToString());
            }
            else
                throw new Exception(response.Message);
        }

        private async Task GetPlayersOnMatchGroupAsync(int id)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetAllUsersByMatchGroupId}{id}";
            var response = await _webApiConnector.GetAsync(getUrl, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Players = JsonConvert.DeserializeObject<List<UserResponse>>(response.Result.ToString());
            }
            else
                throw new Exception(response.Message);
        }

        public IActionResult OnPostChangeGroupName(int id)
        {
            return Redirect($"../ChangeMatchGroupName/{id}");
        }

        public IActionResult OnPostAddUserToMatchGroup(int id)
        {
            return Redirect($"../AddUserToMatchGroup/{id}");
        }
    }
}
