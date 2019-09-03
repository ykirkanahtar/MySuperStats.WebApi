
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
    public class MatchGroupDetailModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        public readonly ISession _session;

        [BindProperty]
        public MatchGroupRequest MatchGroupRequest { get; set; }


        public MatchGroupDetailModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            MatchGroupRequest = new MatchGroupRequest();
        }


        public async Task OnGet(int id)
        {
            try
            {
                var getUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetMatchGroupById}{id}";
                var response = await _webApiConnector.GetAsync(getUrl, SessionUtil.GetToken(_session));
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var matchGroupResponse = JsonConvert.DeserializeObject<MatchGroupResponse>(response.Result.ToString());
                    MatchGroupRequest.GroupName = matchGroupResponse.GroupName;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> OnPostChangeGroupNameAsync(int id)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(MatchGroupRequest);
                var putUrl = $"{_appSettings.WebApiUrl}MatchGroup/{id}/update";
                var response = await _webApiConnector.PutAsync(putUrl, jsonContent, SessionUtil.GetToken(_session));
                return Page();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
