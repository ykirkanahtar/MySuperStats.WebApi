using CustomFramework.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MySuperStats.Contracts.Responses
{
    public class BaseTeamResponse
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string Color { get; set; }
    }

    public class TeamResponse : BaseTeamResponse
    {
        public TeamResponse()
        {
            HomeMatches = new Collection<MatchResponse>();
            AwayMatches = new Collection<MatchResponse>();
            BasketballStats = new Collection<BasketballStatResponse>();
            FootballStats = new Collection<FootballStatResponse>();
        }

        [JsonIgnore]
        public virtual ICollection<MatchResponse> HomeMatches { get; set; }

        [JsonIgnore]
        public virtual ICollection<MatchResponse> AwayMatches { get; set; }

        public virtual ICollection<BasketballStatResponse> BasketballStats { get; set; }
        public virtual ICollection<FootballStatResponse> FootballStats { get; set; }


        public decimal GetAgeRatioForBasketball()
        {
            var teamTotalAge = (from p in BasketballStats
                                select p.Player).Sum(x => x.BirthDate.GetAge());

            return BasketballStats.Count > 0
                ? (Convert.ToDecimal(teamTotalAge) / Convert.ToDecimal(BasketballStats.Count)).RoundValue()
                : 0;
        }

        public decimal GetAgeRatioForFootball()
        {
            var teamTotalAge = (from p in FootballStats
                                select p.Player).Sum(x => x.BirthDate.GetAge());

            return FootballStats.Count > 0
                ? (Convert.ToDecimal(teamTotalAge) / Convert.ToDecimal(FootballStats.Count)).RoundValue()
                : 0;
        }        

        public BasketballStatResponse GetTeamTotalForBasketball()
        {
            return new BasketballStatResponse
            {
                Assist = BasketballStats.Sum(x => x.Assist),
                Interrupt = BasketballStats.Sum(x => x.Interrupt),
                LooseBall = BasketballStats.Sum(x => x.LooseBall),
                MissingOnePoint = BasketballStats.Sum(x => x.MissingOnePoint),
                MissingTwoPoint = BasketballStats.Sum(x => x.MissingTwoPoint),
                OnePoint = BasketballStats.Sum(x => x.OnePoint),
                Rebound = BasketballStats.Sum(x => x.Rebound),
                StealBall = BasketballStats.Sum(x => x.StealBall),
                TwoPoint = BasketballStats.Sum(x => x.TwoPoint),
            };
        }

        public FootballStatResponse GetTeamTotalForFootball()
        {
            return new FootballStatResponse
            {
                Goal = FootballStats.Sum(x => x.Goal),
                OwnGoal = FootballStats.Sum(x => x.OwnGoal),
                PenaltyScore = FootballStats.Sum(x => x.PenaltyScore),
                MissedPenalty = FootballStats.Sum(x => x.MissedPenalty),
                Assist = FootballStats.Sum(x => x.Assist),
                SaveGoal = FootballStats.Sum(x => x.SaveGoal),
                ConcedeGoal = FootballStats.Sum(x => x.ConcedeGoal),
            };
        }        
    }
}
