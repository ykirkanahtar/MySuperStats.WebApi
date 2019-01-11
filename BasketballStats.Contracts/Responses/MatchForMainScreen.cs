using System;

namespace BasketballStats.Contracts.Responses
{
    public class MatchForMainScreen
    {
        public int MatchId { get; set; }
        public DateTime MatchDate { get; set; }
        public int MatchOrder { get; set; }
        public int MatchDuration { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public string VideoLink { get; set; }
    }
}