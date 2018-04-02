using System.Collections.Generic;
using BasketballStats.Contracts.Responses;

namespace BasketballStats.WebSite.Models
{
    public class MatchDetail
    {
        public MatchDetail()
        {
            Teams = new List<TeamDetail>();
        }

        public MatchResponse MatchInfo { get; set; }
        public List<TeamDetail> Teams { get; set; }
    }
}
