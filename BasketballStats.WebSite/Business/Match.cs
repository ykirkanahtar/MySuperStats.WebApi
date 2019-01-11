using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.ApplicationSettings;
using BasketballStats.WebSite.Utils;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BasketballStats.WebSite.Business
{
    public class Match : IMatch
    {
        private readonly IWebApiConnector<WebApiResponse> _webApiConnector;
        private readonly IAppSettings _appSettings;

        public Match(IWebApiConnector<WebApiResponse> webApiConnector, IAppSettings appSettings)
        {
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
        }

        public async Task<List<MatchForMainScreen>> GetAllForMainScreen()
        {
            var getUrl = $"{_appSettings.ApiUrl}{Constants.DefaultApiRoute}match/getallformainscreen";
            var response = await _webApiConnector.GetAsync(getUrl, _appSettings.TokenUrl, _appSettings.Credentials);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return
                    JsonConvert.DeserializeObject<List<MatchForMainScreen>>(response.Result.ToString());

            }

            throw new Exception(response.Message);
        }

        public async Task<MatchDetailStatsResponse> GetMatchDetailStats(int matchId)
        {
            var getUrl = $"{_appSettings.ApiUrl}{Constants.DefaultApiRoute}/match/getmatchdetailstats/id/{matchId}";
            var response = await _webApiConnector.GetAsync(getUrl, _appSettings.TokenUrl, _appSettings.Credentials);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return
                    JsonConvert.DeserializeObject<MatchDetailStatsResponse>(response.Result.ToString());

            }
            else
                throw new Exception(response.Message);
        }

    }
}
