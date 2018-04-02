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
    public class MatchDetailModel : PageModel
    {
        private readonly WebApiConnector _webApiConnector;
        public MatchDetail MatchDetailInfo { get; set; }

        public MatchDetailModel(WebApiConnector webApiConnector)
        {
            _webApiConnector = webApiConnector;
            MatchDetailInfo = new MatchDetail();
        }

        public async Task OnGet(int id)
        {
            var matchId = id; //TODO routing konusunu araştırınca burayı düzelt

            var statResponse =
                await _webApiConnector.GetAsync(
                    $"{Constants.DefaultApiRoute}/stat/getall/matchid/{matchId}");

            if (statResponse.StatusCode == HttpStatusCode.OK)
            {
                var statResponses =
                    JsonConvert.DeserializeObject<List<StatResponse>>(statResponse.Result.ToString());

                var match = statResponses.Select(p => p.Match).Distinct().First();
                MatchDetailInfo.MatchInfo = match;
                var teams = new List<TeamResponse>() { match.HomeTeam, match.AwayTeam };

                foreach (var team in teams)
                {
                    var teamDetail = new TeamDetail { TeamInfo = team };
                    var teamTotalAge = 0;
                    var teamStats = new StatResponse();

                    var players = statResponses.Where(p => p.TeamId == team.Id).Select(p => p.Player).ToList();
                    foreach (var player in players)
                    {
                        var stat = statResponses.FirstOrDefault(p => p.TeamId == team.Id && p.PlayerId == player.Id);
                        if (stat == null) continue;

                        teamStats.OnePoint += stat.OnePoint;
                        teamStats.TwoPoint += stat.TwoPoint;
                        teamStats.MissingOnePoint += stat.MissingOnePoint;
                        teamStats.MissingTwoPoint += stat.MissingTwoPoint;
                        teamStats.Rebound += stat.Rebound;
                        teamStats.StealBall += stat.StealBall;
                        teamStats.LooseBall += stat.LooseBall;
                        teamStats.Assist += stat.Assist;
                        teamStats.Interrupt += stat.Interrupt;

                        teamDetail.PlayerStats.Add(new PlayerStat { Player = player, Stat = stat });
                        teamTotalAge = teamTotalAge + player.BirthDate.GetAge();
                    }

                    teamDetail.AgeRatio = teamDetail.PlayerStats.Count > 0
                        ? (Convert.ToDecimal(teamTotalAge) / Convert.ToDecimal(teamDetail.PlayerStats.Count)).RoundValue()
                        : 0;

                    teamDetail.TeamStats = teamStats;
                    MatchDetailInfo.Teams.Add(teamDetail);
                }

            }
        }
    }
}
