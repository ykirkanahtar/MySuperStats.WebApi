using System.Collections.Generic;
using BasketballStats.Contracts.Responses;

namespace BasketballStats.WebSite.Models
{
    public class TeamDetail
    {
        public TeamDetail()
        {
            PlayerStats = new List<PlayerMatchStat>();
        }

        public TeamResponse TeamInfo { get; set; }
        public decimal AgeRatio { get; set; }
        public List<PlayerMatchStat> PlayerStats { get; set; }
        public StatResponse TeamStats { get; set; }
    }
}