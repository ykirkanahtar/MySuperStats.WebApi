
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Contracts.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;
using MySuperStats.WebUI.Utils;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Pages
{
    public class AddUserToMatchGroupModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        private readonly ISession _session;
        private readonly ILocalizationService _localizer;
        private readonly IPermissionChecker _permissionChecker;

        [BindProperty]
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public AddUserToMatchGroupModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings, IPermissionChecker permissionChecker, ILocalizationService localizer)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            _permissionChecker = permissionChecker;
            _localizer = localizer;
        }

        public async Task OnGet(int id, string culture)
        {
            var user = SessionUtil.GetLoggedUser(_session);

            if (await _permissionChecker.HasPermissionAsync(id, user.Id, PermissionEnum.UpdateMatchGroup, culture) == false)
            {
                throw new UnauthorizedAccessException(_localizer.GetValue("UnauthorizedAccessError"));
            }
        }

        public async Task<IActionResult> OnPostAddUserToMatchGroup(int id, string culture)
        {
            var token = SessionUtil.GetToken(_session);

            try
            {
                var user = await GetUserByEmailAddressAsync(culture, EmailAddress, token);
                var player = await GetPlayerByUserIdAsync(culture, user.Id, token);

                await AddUserToMatchGroupAsync(id, culture, player.Id, token);
                return Redirect($"../MatchGroupDetail/{id}");
            }
            catch (Exception ex)
            {
                ViewData.ModelState.AddModelError("ModelErrors", ex.Message);
            }
            return Page();
        }

        private async Task AddUserToMatchGroupAsync(int matchGroupId, string culture, int playerId, string token)
        {
            var matchGroupUserRequest = new MatchGroupPlayerCreateRequest { MatchGroupId = matchGroupId, PlayerId = playerId };

            var jsonContent = JsonConvert.SerializeObject(matchGroupUserRequest);

            var postUrl = $"{_appSettings.WebApiUrl}{ApiUrls.CreateMatchGroupUser}";

            var response = await _webApiConnector.PostAsync(postUrl, jsonContent, culture, token);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.Message);
        }

        private async Task<UserResponse> GetUserByEmailAddressAsync(string culture, string emailAddress, string token)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetUserByEmailAddress, emailAddress)}";
            var response = await _webApiConnector.GetAsync(getUrl, culture, token);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.Message);

            return JsonConvert.DeserializeObject<UserResponse>(response.Result.ToString());
        }

        private async Task<PlayerResponse> GetPlayerByUserIdAsync(string culture, int userId, string token)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetPlayerByUserId, userId)}";
            var response = await _webApiConnector.GetAsync(getUrl, culture, token);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.Message);

            return JsonConvert.DeserializeObject<PlayerResponse>(response.Result.ToString());
        }
    }
}
