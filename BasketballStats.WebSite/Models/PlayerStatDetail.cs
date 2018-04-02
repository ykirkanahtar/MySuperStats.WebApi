using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballStats.Contracts.Responses;

namespace BasketballStats.WebSite.Models
{
    public class PlayerStatDetail
    {
        public PlayerStatDetail()
        {
            MatchStats = new List<StatResponse>();
        }
        public List<StatResponse> MatchStats { get; set; }
        public decimal HomeTeamScore { get; set; }
        public decimal AwayTeamScore { get; set; }
        public StatResponse PlayerStat { get; set; }

    }
}
