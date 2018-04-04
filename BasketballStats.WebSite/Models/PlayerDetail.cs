using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Enums;
using BasketballStats.WebSite.Pages;

namespace BasketballStats.WebSite.Models
{
    public class PlayerDetail
    {
        public PlayerDetail()
        {
            PlayerStats = new List<PlayerStatDetail>();
            MatchForms = new List<MatchScore>();
        }

        public PlayerResponse Player { get; set; }
        public List<PlayerStatDetail> PlayerStats { get; set; }
        public StatResponse TotalStats { get; set; }
        public StatResponse PerMatchStats { get; set; }
        public decimal OnePointRatio { get; set; }
        public decimal TwoPointRatio { get; set; }
        public decimal TotalWins { get; set; }
        public decimal TotalLooses { get; set; }
        public decimal WinRatio { get; set; }
        public decimal LooseRatio { get; set; }
        public IList<MatchScore> MatchForms { get; set; }
    }
}
