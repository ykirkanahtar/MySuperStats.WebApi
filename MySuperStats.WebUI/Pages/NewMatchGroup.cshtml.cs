
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Contracts.Resources;
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
    public class NewMatchGroupModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        private readonly ISession _session;
        private readonly ILocalizationService _localizer;

        [BindProperty]
        public MatchGroupRequest MatchGroup { get; set; }

        public NewMatchGroupModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings, ILocalizationService localizer)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            MatchGroup = new MatchGroupRequest();
            _localizer = localizer;
        }

        public async Task<IActionResult> OnPostCreateMatchGroupNameAsync(string culture)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelStateHelper.GetErrorListFromModelState(ModelState);
                return Page();
            }

            try
            {
                var jsonContent = JsonConvert.SerializeObject(MatchGroup);

                var postUrl = $"{_appSettings.WebApiUrl}{ApiUrls.CreateMatchGroup}";
                var response = await _webApiConnector.PostAsync(postUrl, jsonContent, culture, SessionUtil.GetToken(_session));
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var matchGroupId = JsonConvert.DeserializeObject<MatchGroupResponse>(response.Result.ToString()).Id;
                    return Redirect($"MatchGroupDetail/{matchGroupId}");
                }
                else
                    throw new Exception(response.Message);
            }
            catch (ValidationException ex)
            {
                ViewData.ModelState.AddModelError("ModelErrors", ex.Message);
            }

            return Page();
        }
    }
}
