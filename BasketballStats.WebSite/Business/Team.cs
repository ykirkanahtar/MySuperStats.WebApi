using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Models;
using BasketballStats.WebSite.Utils;
using System.Collections.Generic;
using System.Linq;

namespace BasketballStats.WebSite.Business
{
    public class Team : ITeam
    {
        public TeamDetail GetTeamDetailByTeamResponse(IStat stat, TeamResponse team, IList<StatResponse> matchStats)
        {
            var teamDetail = new TeamDetail { TeamInfo = team };
            var teamTotalAge = 0;
            var teamStats = new StatResponse();

            var players = matchStats.Where(p => p.TeamId == team.Id).Select(p => p.Player).ToList();
            foreach (var player in players)
            {
                var playerStat = stat.GetPlayerStatByMatchIdAndTeamId(player.Id, team.Id, matchStats);
                if (playerStat == null) continue;

                teamStats = stat.AddPlayerStatToTeamStats(teamStats, playerStat);

                teamDetail.PlayerStats.Add(new PlayerMatchStat { Player = player, Stat = playerStat });
                teamTotalAge = teamTotalAge + player.BirthDate.GetAge();
            }

            teamDetail.AgeRatio = ConvertFunctions.GetTeamAgeRatio(players.Count, teamTotalAge);

            teamDetail.TeamStats = teamStats;
            return teamDetail;
        }

    }
}
