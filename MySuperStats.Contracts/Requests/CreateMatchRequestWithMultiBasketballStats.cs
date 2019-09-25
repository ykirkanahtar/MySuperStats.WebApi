using System.Collections.Generic;

namespace MySuperStats.Contracts.Requests
{
    public class CreateMatchRequestWithMultiBasketballStats
    {
        public CreateMatchRequestWithMultiBasketballStats()
        {
            MatchRequest = new MatchRequest();
            HomeTeamStats = new List<BasketballStatRequestForMultiEntry>();
            AwayTeamStats = new List<BasketballStatRequestForMultiEntry>();
        }

        public MatchRequest MatchRequest { get; set; }
        public List<BasketballStatRequestForMultiEntry> HomeTeamStats { get; set; }
        public List<BasketballStatRequestForMultiEntry> AwayTeamStats { get; set; }
    }
}
