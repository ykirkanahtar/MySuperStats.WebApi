
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
    public class AddGuestToMatchGroupModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        private readonly ISession _session;
        private readonly ILocalizationService _localizer;
        private readonly IPermissionChecker _permissionChecker;

        [BindProperty]
        public CreatePlayerRequest PlayerRequest { get; set; }

        public AddGuestToMatchGroupModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings, IPermissionChecker permissionChecker, ILocalizationService localizer)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            _permissionChecker = permissionChecker;
            _localizer = localizer;
            PlayerRequest = new CreatePlayerRequest();
            PlayerRequest.BirthDate = DateTime.Now.AddYears(-25);
        }

        public async Task<IActionResult> OnPostAddGuest(int id)
        {
            var user = SessionUtil.GetLoggedUser(_session);

            PlayerRequest.MatchGroupId = id;

            var jsonContent = JsonConvert.SerializeObject(PlayerRequest);

            var postUrl = $"{_appSettings.WebApiUrl}{ApiUrls.CreateGuestPlayer}";

            var response = await _webApiConnector.PostAsync(postUrl, jsonContent, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Redirect($"../MatchGroupDetail/{id}");
            }
            else
                ViewData.ModelState.AddModelError("ModelErrors", response.Message);

            return Page();
        }
    }
}
