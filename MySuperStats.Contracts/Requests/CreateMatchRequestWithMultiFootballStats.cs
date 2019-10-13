using System.Collections.Generic;

namespace MySuperStats.Contracts.Requests
{
    public class CreateMatchRequestWithMultiFootballStats
    {
        public CreateMatchRequestWithMultiFootballStats()
        {
            MatchRequest = new MatchRequest();
            HomeTeamStats = new List<FootballStatRequestForMultiEntry>();
            AwayTeamStats = new List<FootballStatRequestForMultiEntry>();
        }

        public MatchRequest MatchRequest { get; set; }
        public List<FootballStatRequestForMultiEntry> HomeTeamStats { get; set; }
        public List<FootballStatRequestForMultiEntry> AwayTeamStats { get; set; }
    }    
}
