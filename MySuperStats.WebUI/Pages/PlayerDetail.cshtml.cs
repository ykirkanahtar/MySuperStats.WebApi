
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
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
    public class PlayerDetailModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        public readonly ISession _session;

        public UserDetailWithBasketballStatResponse PlayerBasketballStats { get; set; }
        public UserDetailWithFootballStatResponse PlayerFootballStats { get; set; }

        public List<BasketballStatResponse> BasketballStats { get; set; }
        public List<FootballStatResponse> FootballStats { get; set; }

        public MatchGroupResponse MatchGroup { get; set; }

        public PlayerResponse Player { get; set; }

        public PlayerDetailModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            PlayerBasketballStats = new UserDetailWithBasketballStatResponse();
            PlayerFootballStats = new UserDetailWithFootballStatResponse();
            BasketballStats = new List<BasketballStatResponse>();
            FootballStats = new List<FootballStatResponse>();
            Player = new PlayerResponse();
        }

        public async Task OnGetAsync(int id, string culture, int matchGroupId)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetMatchGroupByMatchId, matchGroupId)}";
            var response = await _webApiConnector.GetAsync(getUrl, culture, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                MatchGroup = JsonConvert.DeserializeObject<MatchGroupResponse>(response.Result.ToString());
                if (MatchGroup.MatchGroupType == MatchGroupType.Basketball)
                {
                    await OnGetBasketballStatsAsync(id, culture, matchGroupId);
                }
                else if (MatchGroup.MatchGroupType == MatchGroupType.Football)
                {
                    await OnGetFootballStatsAsync(id, culture, matchGroupId);
                }
            }
            else
                throw new Exception(response.Message);
        }

        public async Task OnGetBasketballStatsAsync(int id, string culture, int matchGroupId)
        {
            try
            {
                var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetPlayerWithBasketballStats, id, matchGroupId)}";
                var response = await _webApiConnector.GetAsync(getUrl, culture, SessionUtil.GetToken(_session));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    PlayerBasketballStats = JsonConvert.DeserializeObject<UserDetailWithBasketballStatResponse>(response.Result.ToString());
                    BasketballStats = PlayerBasketballStats.Player.BasketballStats.OrderBy(p => p.Match.MatchDate).ThenBy(p => p.Match.Order).ToList();
                    Player = PlayerBasketballStats.Player;
                }
                else
                    throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task OnGetFootballStatsAsync(int id, string culture, int matchGroupId)
        {
            try
            {
                var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetPlayerWithFootballStats, id, matchGroupId)}";
                var response = await _webApiConnector.GetAsync(getUrl, culture, SessionUtil.GetToken(_session));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    PlayerFootballStats = JsonConvert.DeserializeObject<UserDetailWithFootballStatResponse>(response.Result.ToString());
                    FootballStats = PlayerFootballStats.Player.FootballStats.OrderBy(p => p.Match.MatchDate).ThenBy(p => p.Match.Order).ToList();
                    Player = PlayerFootballStats.Player;
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
