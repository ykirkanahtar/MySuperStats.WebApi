
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public readonly ISession _session;

        [BindProperty]
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public AddUserToMatchGroupModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
        }

        public async Task<IActionResult> OnPostAddUserToMatchGroup(int id)
        {
            var token = SessionUtil.GetToken(_session);

            try
            {
                var user = await GetUserByEmailAddressAsync(EmailAddress, token);

                await AddUserToMatchGroupAsync(id, user.Id, token);
                return Redirect($"../MatchGroupDetail/{id}");
            }
            catch (Exception ex)
            {
                ViewData.ModelState.AddModelError("ModelErrors", ex.Message);
            }
            return Page();
        }

        private async Task AddUserToMatchGroupAsync(int matchGroupId, int userId, string token)
        {
            var matchGroupUserRequest = new MatchGroupUserRequest { MatchGroupId = matchGroupId, UserId = userId };

            var jsonContent = JsonConvert.SerializeObject(matchGroupUserRequest);

            var postUrl = $"{_appSettings.WebApiUrl}{ApiUrls.CreateMatchGroupUser}";

            var response = await _webApiConnector.PostAsync(postUrl, jsonContent, token);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.Message);
        }

        private async Task<UserResponse> GetUserByEmailAddressAsync(string emailAddress, string token)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetUserByEmailAddress}{emailAddress}";
            var response = await _webApiConnector.GetAsync(getUrl, token);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.Message);

            return JsonConvert.DeserializeObject<UserResponse>(response.Result.ToString());
        }
    }
}
