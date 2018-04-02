using BasketballStats.WebSite.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Models;

namespace BasketballStats.WebSite.Pages
{
    public class PlayerDetailModel : PageModel
    {
        private readonly WebApiConnector _webApiConnector;
        public PlayerDetail PlayerDetailInfo { get; set; }

        public PlayerDetailModel(WebApiConnector webApiConnector)
        {
            _webApiConnector = webApiConnector;
            PlayerDetailInfo = new PlayerDetail();
        }

        public async Task OnGet(int id)
        {
            var playerId = id;
            var playerResponse =
                await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/player/get/id/{playerId}");
            if (playerResponse.StatusCode == HttpStatusCode.OK)
            {
                var player = JsonConvert.DeserializeObject<PlayerResponse>(playerResponse.Result.ToString());
                PlayerDetailInfo.Player = player;

                var statResponse = await _webApiConnector.GetAsync(
                    $"{Constants.DefaultApiRoute}/stat/getall/playerid/{playerId}");
                if (statResponse.StatusCode == HttpStatusCode.OK)
                {
                    var stats = JsonConvert.DeserializeObject<List<StatResponse>>(statResponse.Result.ToString())
                        .OrderBy(p => p.Match.MatchDate).ThenBy(p => p.Match.Order).ThenBy(p => p.Team.Id).ToList();

                    var totalStats = new StatResponse
                    {
                        OnePoint = (from p in stats select p.OnePoint).Sum(),
                        MissingOnePoint = (from p in stats select p.MissingOnePoint).Sum(),
                        TwoPoint = (from p in stats select p.TwoPoint).Sum(),
                        MissingTwoPoint = (from p in stats select p.MissingTwoPoint).Sum(),
                        Rebound = (from p in stats select p.Rebound).Sum(),
                        StealBall = (from p in stats select p.StealBall).Sum(),
                        Assist = (from p in stats select p.Assist).Sum(),
                        LooseBall = (from p in stats select p.LooseBall).Sum(),
                        Interrupt = (from p in stats select p.Interrupt).Sum()
                    };

                    var matchCount = GetMatchCount.All(stats);
                    var twoPointMatchCount = GetMatchCount.GetByTwoPointStat(stats);

                    var perMatchStats = new StatResponse
                    {
                        OnePoint = (totalStats.OnePoint / matchCount).RoundValue(),
                        MissingOnePoint = (totalStats.MissingOnePoint / matchCount).RoundValue(),
                        TwoPoint = twoPointMatchCount > 0 ? (totalStats.TwoPoint / twoPointMatchCount).RoundValue() : 0,
                        MissingTwoPoint = twoPointMatchCount > 0 ? (totalStats.MissingTwoPoint / twoPointMatchCount).RoundValue() : 0,
                        Rebound = (totalStats.Rebound / matchCount).RoundValue(),
                        StealBall = (totalStats.StealBall / matchCount).RoundValue(),
                        Assist = (totalStats.Assist / matchCount).RoundValue(),
                        LooseBall = (totalStats.LooseBall / matchCount).RoundValue(),
                        Interrupt = (totalStats.Interrupt / matchCount).RoundValue(),
                    };

                    PlayerDetailInfo.OnePointRatio = ((totalStats.OnePoint + totalStats.MissingOnePoint) > 0 ?
                        (totalStats.OnePoint * 100) / (totalStats.OnePoint + totalStats.MissingOnePoint) : 0).RoundValue();
                    PlayerDetailInfo.TwoPointRatio = ((totalStats.TwoPoint + totalStats.MissingTwoPoint) > 0 ?
                        (totalStats.TwoPoint * 100) / (totalStats.TwoPoint + totalStats.MissingTwoPoint) : 0).RoundValue();

                    PlayerDetailInfo.TotalStats = totalStats;
                    PlayerDetailInfo.PerMatchStats = perMatchStats;

                    foreach (var stat in stats)
                    {
                        var playerStatDetail = new PlayerStatDetail { PlayerStat = stat };

                        var matchStatResponse = await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/stat/getall/matchid/{stat.Match.Id}");

                        if (matchStatResponse.StatusCode == HttpStatusCode.OK)
                        {
                            var matchStats = JsonConvert.DeserializeObject<List<StatResponse>>(matchStatResponse.Result.ToString());

                            playerStatDetail.HomeTeamScore = (from p in matchStats
                                                              where p.TeamId == stat.Match.HomeTeamId
                                                              select p.OnePoint + p.TwoPoint * 2).Sum();

                            playerStatDetail.AwayTeamScore = (from p in matchStats
                                                              where p.TeamId == stat.Match.AwayTeamId
                                                              select p.OnePoint + p.TwoPoint * 2).Sum();

                            playerStatDetail.MatchStats = matchStats;
                        }
                        PlayerDetailInfo.PlayerStats.Add(playerStatDetail);
                    }
                }
            }
        }
    }
}
