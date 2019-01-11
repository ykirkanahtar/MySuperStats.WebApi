using BasketballStats.Contracts.Enums;
using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BasketballStats.WebSite.ApplicationSettings;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;

namespace BasketballStats.WebSite.Business
{
    public class Stat : IStat
    {
        private readonly IWebApiConnector<WebApiResponse> _webApiConnector;
        private readonly IAppSettings _appSettings;

        public Stat(IWebApiConnector<WebApiResponse> webApiConnector, IAppSettings appSettings)
        {
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
        }

        public async Task<StatisticTable> GetTopStats()
        {
            var getUrl = $"{_appSettings.ApiUrl}{Constants.DefaultApiRoute}/stat/gettopstats";
            var response = await _webApiConnector.GetAsync(getUrl, _appSettings.TokenUrl, _appSettings.Credentials);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return
                    JsonConvert.DeserializeObject<StatisticTable>(response.Result.ToString());

            }
            else
                throw new Exception(response.Message);
        }
    }
}
