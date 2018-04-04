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
    public class Player : IPlayer
    {
        private readonly IWebApiConnector _webApiConnector;
        public Player(IWebApiConnector webApiConnector)
        {
            _webApiConnector = webApiConnector;
        }

        public async Task<PlayerResponse> GetById(int playerId)
        {
            var getUrl = $"{Constants.DefaultApiRoute}/player/get/id/{playerId}";
            var response = await _webApiConnector.GetAsync(getUrl);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return
                    JsonConvert.DeserializeObject<PlayerResponse>(response.Result.ToString());

            }
            else
                throw new Exception(response.Message);
        }

        public async Task<List<PlayerResponse>> GetAll()
        {
            var getUrl = $"{Constants.DefaultApiRoute}/player/getall";
            var response = await _webApiConnector.GetAsync(getUrl);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return
                    JsonConvert.DeserializeObject<List<PlayerResponse>>(response.Result.ToString());

            }
            else
                throw new Exception(response.Message);
        }

        public List<PlayerResponse> GetPlayersByTeamIdAndStats(int teamId, List<StatResponse> stats)
        {
            return stats.Where(p => p.TeamId == teamId).Select(p => p.Player).ToList();
        }
    }
}
