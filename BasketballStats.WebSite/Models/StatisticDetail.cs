using System;
using System.Collections.Generic;
using System.Linq;
using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Enums;
using BasketballStats.WebSite.Utils;

namespace BasketballStats.WebSite.Models
{
    public class StatisticDetail
    {
        public StatisticDetail()
        {
            MatchForms = new List<MatchScore>();
        }

        public PlayerResponse Player { get; set; }
        public StatResponse TotalStatDetail { get; set; }
        public StatResponse PerMatchStatDetail { get; set; }
        public decimal TotalPoint { get; set; }
        public decimal PerMatchTotalPoint { get; set; }
        public decimal OnePointRatio { get; set; }
        public decimal TwoPointRatio { get; set; }
        public int MatchCount { get; set; }
        public int TwoPointMatchCount { get; set; }
        public IList<MatchScore> MatchForms { get; set; }
        public decimal WinRatio { get; set; }
        public decimal LooseRatio { get; set; }
    }
}