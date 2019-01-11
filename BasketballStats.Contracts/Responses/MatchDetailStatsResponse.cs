using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using CustomFramework.Utils;

namespace BasketballStats.Contracts.Responses
{
    public class MatchDetailStatsResponse
    {
        public MatchDetailStatsResponse()
        {
            HomeTeamStats = new TeamStatsResponse();
            AwayTeamStats = new TeamStatsResponse();
        }

        public DateTime MatchDate { get; set; }
        public int MatchOrder { get; set; }
        public string VideoLink { get; set; }
        public TeamStatsResponse HomeTeamStats { get; set; }
        public TeamStatsResponse AwayTeamStats { get; set; }
    }

    public class TeamStatsResponse
    {
        public TeamStatsResponse()
        {
            PlayerStats = new List<PlayerStatsResponse>();
        }

        public TeamResponse Team { get; set; }
        public List<PlayerStatsResponse> PlayerStats { get; set; }

        public decimal GetAgeRatio()
        {
            var teamTotalAge = (from p in PlayerStats
                                select p.Player).Sum(x => x.BirthDate.GetAge());

            return PlayerStats.Count > 0
                ? (Convert.ToDecimal(teamTotalAge) / Convert.ToDecimal(PlayerStats.Count)).RoundValue()
                : 0;
        }

        public StatResponse GetTeamTotal()
        {
            var statResponses = (from p in PlayerStats
                             select p.Stat).ToArray();

            return new StatResponse
            {
                Assist = statResponses.Sum(x => x.Assist),
                Interrupt = statResponses.Sum(x => x.Interrupt),
                LooseBall = statResponses.Sum(x => x.LooseBall),
                MissingOnePoint = statResponses.Sum(x => x.MissingOnePoint),
                MissingTwoPoint = statResponses.Sum(x => x.MissingTwoPoint),
                OnePoint = statResponses.Sum(x => x.OnePoint),
                Rebound = statResponses.Sum(x => x.Rebound),
                StealBall = statResponses.Sum(x => x.StealBall),
                TwoPoint = statResponses.Sum(x => x.TwoPoint),
            };
        }
    }

    public class PlayerStatsResponse
    {
        public PlayerResponse Player { get; set; }
        public StatResponse Stat { get; set; }
    }

}
