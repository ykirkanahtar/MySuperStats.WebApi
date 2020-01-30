using System;
using System.Net;
using System.Threading.Tasks;
using CustomFramework.BaseWebApi.Contracts.ApiContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;
using MySuperStats.WebUI.Utils;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Pages
{
    public class MatchDetailModel : PageModel
    {
        private readonly IWebApiConnector<WebApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        public readonly ISession _session;
        public MatchResponse Match { get; set; }
        public MatchGroupResponse MatchGroup { get; set; }

        public MatchDetailModel(ISession session, IWebApiConnector<WebApiResponse> webApiConnector, AppSettings appSettings)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            Match = new MatchResponse();
        }

        public async Task OnGetAsync(int id, string culture)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetMatchGroupByMatchId, id)}";
            var response = await _webApiConnector.GetAsync(getUrl, culture, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                MatchGroup = JsonConvert.DeserializeObject<MatchGroupResponse>(response.Result.ToString());
                if(MatchGroup.MatchGroupType == MatchGroupType.Basketball)
                {
                    await OnGetBasketballStats(id, culture);
                }
                else if (MatchGroup.MatchGroupType == MatchGroupType.Football)
                {
                    await OnGetFootballStats(id, culture);
                }
            }
            else
                throw new Exception(response.Message);
        }

        public async Task OnGetBasketballStats(int id, string culture)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetMatchDetailBasketballStats, id)}";
            var response = await _webApiConnector.GetAsync(getUrl, culture, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Match = JsonConvert.DeserializeObject<MatchResponse>(response.Result.ToString());
            }
            else
                throw new Exception(response.Message);
        }

        public async Task OnGetFootballStats(int id, string culture)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetMatchDetailFootballStats, id)}";
            var response = await _webApiConnector.GetAsync(getUrl, culture, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Match = JsonConvert.DeserializeObject<MatchResponse>(response.Result.ToString());
            }
            else
                throw new Exception(response.Message);
        }        
    }
}
