
using System;
using System.Net;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Contracts.Resources;
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
    public class TopFootballStatsModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        private readonly ISession _session;
        private readonly ILocalizationService _localizer;

        public FootballStatisticTable StatisticTable { get; set; }

        public TopFootballStatsModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings, ILocalizationService localizer)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            StatisticTable = new FootballStatisticTable();
            _localizer = localizer;
        }

        public async Task OnGetAsync(int id, string culture)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetMatchGroupById, id)}";
            var response = await _webApiConnector.GetAsync(getUrl, culture, SessionUtil.GetToken(_session));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var matchGroupResponse = JsonConvert.DeserializeObject<MatchGroupResponse>(response.Result.ToString());
                if (matchGroupResponse.MatchGroupType != MatchGroupType.Football)
                {
                    throw new ArgumentException(_localizer.GetValue("This group is just for football stats"));
                }
                else
                {
                    await OnGetTopStatsAsync(id, culture);
                }
            }
            else
                throw new Exception(response.Message);
        }

        public async Task OnGetTopStatsAsync(int id, string culture)
        {
            try
            {
                var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetTopFootballStats, id)}";
                var response = await _webApiConnector.GetAsync(getUrl, culture, SessionUtil.GetToken(_session));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StatisticTable = JsonConvert.DeserializeObject<FootballStatisticTable>(response.Result.ToString());
                }
                else
                    throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
