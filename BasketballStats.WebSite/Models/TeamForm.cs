using System.Collections.Generic;
using BasketballStats.Contracts.Responses;

namespace BasketballStats.WebSite.Models
{
    public class TeamForm
    {
        public TeamForm()
        {
            HomeTeamPlayerIds = new List<int>();
            AwayTeamPlayerIds = new List<int>();
        }

        public MatchResponse Match { get; set; }
        public int HomeTeamId { get; set; }
        public decimal HomeTeamScore { get; set; }
        public int AwayTeamId { get; set; }
        public decimal AwayTeamScore { get; set; }

        public List<int> HomeTeamPlayerIds { get; set; }
        public List<int> AwayTeamPlayerIds { get; set; }
    }
}