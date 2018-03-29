using System;
using BasketballStats.WebSite.ResponseModels;
using BasketballStats.WebSite.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BasketballStats.WebSite.Pages
{
    public class MatchDetailModel : PageModel
    {
        private readonly WebApiConnector _webApiConnector;
        public MatchDetail MatchDetail;

        public MatchDetailModel(WebApiConnector webApiConnector)
        {
            _webApiConnector = webApiConnector;
            MatchDetail = new MatchDetail();
        }

        public async Task OnGet(int id)
        {
            int matchId = id; //TODO routing konusunu araştırınca burayı düzelt

            var matchResponse = await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/match/get/id/{matchId}");
            if (matchResponse.StatusCode == HttpStatusCode.OK)
            {
                var match = JsonConvert.DeserializeObject<MatchResponse>(matchResponse.Result.ToString());
                MatchDetail.MatchInfo = match;

                var teamResponse =
                    await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/stat/getallteams/matchid/{matchId}");
                if (teamResponse.StatusCode == HttpStatusCode.OK)
                {
                    var teamResponses =
                        JsonConvert.DeserializeObject<List<TeamResponse>>(teamResponse.Result.ToString());
                    foreach (var team in teamResponses)
                    {
                        var teamDetail = new TeamDetail { TeamInfo = team };
                        var teamStats = new StatResponse();

                        var teamTotalAge = 0;

                        var playerResponse =
                            await _webApiConnector.GetAsync(
                                $"{Constants.DefaultApiRoute}/stat/getallplayers/matchid/{matchId}/teamid/{team.Id}");

                        if (playerResponse.StatusCode == HttpStatusCode.OK)
                        {
                            var playerResponses =
                                JsonConvert.DeserializeObject<List<PlayerResponse>>(playerResponse.Result.ToString());
                            teamDetail.PlayerCount = playerResponses.Count;

                            foreach (var player in playerResponses)
                            {
                                var playerStat = new PlayerStat { Player = player };

                                var statResponse = await _webApiConnector.GetAsync(
                                    $"{Constants.DefaultApiRoute}/stat/get/matchid/{matchId}/teamid/{team.Id}/playerid/{player.Id}");

                                if (statResponse.StatusCode == HttpStatusCode.OK)
                                {
                                    playerStat.Stat =
                                        JsonConvert.DeserializeObject<StatResponse>(statResponse.Result.ToString());
                                }

                                teamStats.OnePoint += playerStat.Stat.OnePoint;
                                teamStats.TwoPoint += playerStat.Stat.TwoPoint;
                                teamStats.MissingOnePoint += playerStat.Stat.MissingOnePoint;
                                teamStats.MissingTwoPoint += playerStat.Stat.MissingTwoPoint;
                                teamStats.Rebound += playerStat.Stat.Rebound;
                                teamStats.StealBall += playerStat.Stat.StealBall;
                                teamStats.LooseBall += playerStat.Stat.LooseBall;
                                teamStats.Assist += playerStat.Stat.Assist;
                                teamStats.Interrupt += playerStat.Stat.Interrupt;

                                teamDetail.PlayerStats.Add(playerStat);
                                teamTotalAge = teamTotalAge + player.BirthDate.GetAge();
                            }
                        }
                        teamDetail.AgeRatio = teamDetail.PlayerCount > 0 ?
                            (Convert.ToDecimal(teamTotalAge) / Convert.ToDecimal(teamDetail.PlayerCount)).RoundValue() : 0;

                        teamDetail.TeamStats = teamStats;
                        MatchDetail.Teams.Add(teamDetail);
                    }
                }
            }
        }
    }

    public class MatchDetail
    {
        public MatchDetail()
        {
            Teams = new List<TeamDetail>();
        }

        public MatchResponse MatchInfo { get; set; }
        public List<TeamDetail> Teams { get; set; }
    }

    public class TeamDetail
    {
        public TeamDetail()
        {
            PlayerStats = new List<PlayerStat>();
        }

        public TeamResponse TeamInfo { get; set; }
        public decimal AgeRatio { get; set; }
        public int PlayerCount { get; set; }
        public List<PlayerStat> PlayerStats { get; set; }
        public StatResponse TeamStats { get; set; }
    }

    public class PlayerStat
    {
        public PlayerResponse Player { get; set; }
        public StatResponse Stat { get; set; }
    }
}
