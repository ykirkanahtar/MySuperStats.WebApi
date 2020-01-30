
using System;
using System.Net;
using System.Threading.Tasks;
using CustomFramework.BaseWebApi.Contracts.ApiContracts;
using CustomFramework.BaseWebApi.Resources;
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
    public class ChangeMatchGroupNameModel : PageModel
    {
        private readonly IWebApiConnector<WebApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        private readonly ISession _session;
        private readonly IPermissionChecker _permissionChecker;
        private readonly ILocalizationService _localizer;


        [BindProperty]
        public MatchGroupRequest MatchGroupRequest { get; set; }

        public ChangeMatchGroupNameModel(ISession session, IWebApiConnector<WebApiResponse> webApiConnector, AppSettings appSettings, IPermissionChecker permissionChecker, ILocalizationService localizer)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            _permissionChecker = permissionChecker;

            MatchGroupRequest = new MatchGroupRequest();
            _localizer = localizer;
        }


        public async Task OnGet(int id, string culture)
        {
            var user = SessionUtil.GetLoggedUser(_session);

            if (await _permissionChecker.HasPermissionAsync(id, user.Id, PermissionEnum.UpdateMatchGroup, culture) == false)
            {
                throw new UnauthorizedAccessException(_localizer.GetValue("UnauthorizedAccessError"));
            }

            var matchGroupResponse = await OnGetById(id, culture);
            MatchGroupRequest.GroupName = matchGroupResponse.GroupName;
        }

        public async Task<IActionResult> OnPostChangeGroupNameAsync(int id, string culture)
        {
            var matchGroupResponse = await OnGetById(id, culture);
            MatchGroupRequest.MatchGroupType = matchGroupResponse.MatchGroupType;

            var jsonContent = JsonConvert.SerializeObject(MatchGroupRequest);
            var putUrl = $"{_appSettings.WebApiUrl}MatchGroup/{id}/update";
            var response = await _webApiConnector.PutAsync(putUrl, jsonContent, culture, SessionUtil.GetToken(_session));
            if (response.StatusCode == HttpStatusCode.OK)
                return Redirect($"../MatchGroupDetail/{id}");
            else
                ViewData.ModelState.AddModelError("ModelErrors", response.Message);

            return Page();
        }

        private async Task<MatchGroupResponse> OnGetById(int id, string culture)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetMatchGroupById, id)}";
            var response = await _webApiConnector.GetAsync(getUrl, culture, SessionUtil.GetToken(_session));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<MatchGroupResponse>(response.Result.ToString());
            }
            else
                throw new Exception(response.Message);
        }
    }
}
