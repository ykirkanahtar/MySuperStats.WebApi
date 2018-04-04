using System.Collections.Generic;
using BasketballStats.Contracts.Responses;

namespace BasketballStats.WebSite.Models
{
    public class MatchDetail
    {
        public MatchResponse MatchInfo { get; set; }
        public TeamDetail HomeTeam { get; set; }
        public TeamDetail AwayTeam { get; set; }
        public decimal HomeTeamScore { get; set; }
        public decimal AwayTeamScore { get; set; }
    }
}
