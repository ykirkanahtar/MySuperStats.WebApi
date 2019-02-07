using System;
using System.Collections.Generic;
using System.Linq;
using CustomFramework.Utils;

namespace MySuperStats.Contracts.Responses
{
    public class TeamBasketballStatsResponse
    {
        public TeamBasketballStatsResponse()
        {
            PlayerBasketballStats = new List<PlayerBasketballStatsResponse>();
        }

        public TeamResponse Team { get; set; }
        public List<PlayerBasketballStatsResponse> PlayerBasketballStats { get; set; }

        public decimal GetAgeRatio()
        {
            var teamTotalAge = (from p in PlayerBasketballStats
                                select p.Player).Sum(x => x.BirthDate.GetAge());

            return PlayerBasketballStats.Count > 0
                ? (Convert.ToDecimal(teamTotalAge) / Convert.ToDecimal(PlayerBasketballStats.Count)).RoundValue()
                : 0;
        }

        public BasketballStatResponse GetTeamTotal()
        {
            var statResponses = (from p in PlayerBasketballStats
                             select p.BasketballStat).ToArray();

            return new BasketballStatResponse
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

}
