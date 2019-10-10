
using System;
using System.Net;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
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
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        private readonly ISession _session;
        private readonly IPermissionChecker _permissionChecker;


        [BindProperty]
        public MatchGroupRequest MatchGroupRequest { get; set; }

        public ChangeMatchGroupNameModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings, IPermissionChecker permissionChecker)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            _permissionChecker = permissionChecker;

            MatchGroupRequest = new MatchGroupRequest();
        }


        public async Task OnGet(int id, string culture)
        {
            var user = SessionUtil.GetLoggedUser(_session);

            if (await _permissionChecker.HasPermissionAsync(id, user.Id, PermissionEnum.UpdateMatchGroup, culture) == false)
            {
                throw new UnauthorizedAccessException("Bu sayfayı görüntülemeye yetkiniz yok");
            }

            var getUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetMatchGroupById}{id}";
            var response = await _webApiConnector.GetAsync(getUrl, culture, SessionUtil.GetToken(_session));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var matchGroupResponse = JsonConvert.DeserializeObject<MatchGroupResponse>(response.Result.ToString());
                MatchGroupRequest.GroupName = matchGroupResponse.GroupName;
            }
        }

        public async Task<IActionResult> OnPostChangeGroupNameAsync(int id, string culture)
        {
            var jsonContent = JsonConvert.SerializeObject(MatchGroupRequest);
            var putUrl = $"{_appSettings.WebApiUrl}MatchGroup/{id}/update";
            var response = await _webApiConnector.PutAsync(putUrl, jsonContent, culture, SessionUtil.GetToken(_session));
            if (response.StatusCode == HttpStatusCode.OK)
                return Redirect($"../MatchGroupDetail/{id}");
            else
                ViewData.ModelState.AddModelError("ModelErrors", response.Message);

            return Page();
        }
    }
}
