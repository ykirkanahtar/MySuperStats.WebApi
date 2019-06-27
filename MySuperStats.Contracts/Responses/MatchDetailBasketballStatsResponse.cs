using System;
using System.ComponentModel.DataAnnotations;

namespace MySuperStats.Contracts.Responses
{
    public class MatchDetailBasketballStatsResponse
    {
        public MatchDetailBasketballStatsResponse()
        {
            HomeTeamBasketballStats = new TeamBasketballStatsResponse();
            AwayTeamBasketballStats = new TeamBasketballStatsResponse();
        }

        public DateTime MatchDate { get; set; }
        public int MatchOrder { get; set; }
        public string VideoLink { get; set; }
        public TeamBasketballStatsResponse HomeTeamBasketballStats { get; set; }
        public TeamBasketballStatsResponse AwayTeamBasketballStats { get; set; }
    }
}
