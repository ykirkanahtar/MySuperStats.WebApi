using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BasketballStats.WebSite.ResponseModels;
using BasketballStats.WebSite.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BasketballStats.WebSite.Pages
{
    public class PlayerDetailModel : PageModel
    {
        private readonly WebApiConnector _webApiConnector;
        public PlayerDetail PlayerDetail;

        public PlayerDetailModel(WebApiConnector webApiConnector)
        {
            _webApiConnector = webApiConnector;
            PlayerDetail = new PlayerDetail();
        }

        public async Task OnGet(int id)
        {
            var playerId = id;
            var playerResponse =
                await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/player/get/id/{playerId}");
            if (playerResponse.StatusCode == HttpStatusCode.OK)
            {
                var player = JsonConvert.DeserializeObject<PlayerResponse>(playerResponse.Result.ToString());
                PlayerDetail.Player = player;

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

                    var matchCount = stats.Count;

                    var ratioStats = new StatResponse
                    {
                        OnePoint = (totalStats.OnePoint / matchCount).RoundValue(),
                        MissingOnePoint = (totalStats.MissingOnePoint / matchCount).RoundValue(),
                        TwoPoint = (totalStats.TwoPoint / matchCount).RoundValue(),
                        MissingTwoPoint = (totalStats.MissingTwoPoint / matchCount).RoundValue(),
                        Rebound = (totalStats.Rebound / matchCount).RoundValue(),
                        StealBall = (totalStats.StealBall / matchCount).RoundValue(),
                        Assist = (totalStats.Assist / matchCount).RoundValue(),
                        LooseBall = (totalStats.LooseBall / matchCount).RoundValue(),
                        Interrupt = (totalStats.Interrupt / matchCount).RoundValue(),
                    };

                    PlayerDetail.OnePointRatio = ((totalStats.OnePoint + totalStats.MissingOnePoint) > 0 ?
                        (totalStats.OnePoint * 100) / (totalStats.OnePoint + totalStats.MissingOnePoint) : 0).RoundValue();
                    PlayerDetail.TwoPointRatio = ((totalStats.TwoPoint + totalStats.MissingTwoPoint) > 0 ?
                        (totalStats.TwoPoint * 100) / (totalStats.TwoPoint + totalStats.MissingTwoPoint) : 0).RoundValue();

                    PlayerDetail.TotalStats = totalStats;
                    PlayerDetail.RatioStats = ratioStats;

                    foreach (var stat in stats)
                    {
                        var customStatDetail = new CustomStatDetail() { PlayerStatDetail = stat };

                        var matchStatResponse = await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/stat/getall/matchid/{stat.Match.Id}");

                        if (matchStatResponse.StatusCode == HttpStatusCode.OK)
                        {
                            var matchStats = JsonConvert.DeserializeObject<List<StatResponse>>(matchStatResponse.Result.ToString());

                            customStatDetail.HomeTeamScore = (from p in matchStats
                                                              where p.TeamId == stat.Match.HomeTeamId
                                                              select p.OnePoint + p.TwoPoint).Sum();

                            customStatDetail.AwayTeamScore = (from p in matchStats
                                                              where p.TeamId == stat.Match.AwayTeamId
                                                              select p.OnePoint + p.TwoPoint).Sum();

                            customStatDetail.MatchStats = matchStats;
                        }
                        PlayerDetail.CustomStats.Add(customStatDetail);
                    }
                }
            }
        }
    }


    public class PlayerDetail
    {
        public PlayerDetail()
        {
            CustomStats = new List<CustomStatDetail>();
        }

        public PlayerResponse Player { get; set; }
        public List<CustomStatDetail> CustomStats { get; set; }
        public StatResponse TotalStats { get; set; }
        public StatResponse RatioStats { get; set; }
        public decimal OnePointRatio { get; set; }
        public decimal TwoPointRatio { get; set; }
    }

    public class CustomStatDetail
    {
        public CustomStatDetail()
        {
            MatchStats = new List<StatResponse>();
        }

        public List<StatResponse> MatchStats { get; set; }
        public decimal HomeTeamScore { get; set; }
        public decimal AwayTeamScore { get; set; }
        public StatResponse PlayerStatDetail { get; set; }
    }
}
