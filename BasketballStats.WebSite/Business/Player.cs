using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Utils;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BasketballStats.WebSite.ApplicationSettings;

namespace BasketballStats.WebSite.Business
{
    public class Player : IPlayer
    {
        private readonly IWebApiConnector<WebApiResponse> _webApiConnector;
        private readonly IAppSettings _appSettings;

        public Player(IWebApiConnector<WebApiResponse> webApiConnector, IAppSettings appSettings)
        {
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
        }

        public async Task<PlayerDetailResponse> GetWithStatsById(int playerId)
        {
            var getUrl = $"{_appSettings.ApiUrl}{Constants.DefaultApiRoute}/player/getwithstats/id/{playerId}";
            var response = await _webApiConnector.GetAsync(getUrl, _appSettings.TokenUrl, _appSettings.Credentials);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return
                    JsonConvert.DeserializeObject<PlayerDetailResponse>(response.Result.ToString());
            }

            throw new Exception(response.Message);
        }

        public async Task<List<PlayerResponse>> GetAll()
        {
            var getUrl = $"{_appSettings.ApiUrl}{Constants.DefaultApiRoute}/player/getall";
            var response = await _webApiConnector.GetAsync(getUrl, _appSettings.TokenUrl, _appSettings.Credentials);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return
                    JsonConvert.DeserializeObject<List<PlayerResponse>>(response.Result.ToString());

            }

            throw new Exception(response.Message);
        }
    }
}
