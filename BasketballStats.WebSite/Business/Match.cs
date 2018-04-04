using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BasketballStats.WebSite.Business
{
    public class Match : IMatch
    {
        private readonly IWebApiConnector _webApiConnector;
        public Match(IWebApiConnector webApiConnector)
        {
            _webApiConnector = webApiConnector;
        }

        public async Task<List<MatchResponse>> GetAll()
        {
            var getUrl = $"{Constants.DefaultApiRoute}/match/getall";
            var response = await _webApiConnector.GetAsync(getUrl);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return
                    JsonConvert.DeserializeObject<List<MatchResponse>>(response.Result.ToString());

            }
            else
                throw new Exception(response.Message);
        }
    }
}
