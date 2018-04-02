using System.Collections.Generic;
using BasketballStats.Contracts.Responses;

namespace BasketballStats.WebSite.Models
{
    public class StatisticDetail
    {
        public StatisticDetail()
        {
            MatchStatus = new List<string>();
        }

        public PlayerResponse Player { get; set; }
        public StatResponse TotalStatDetail { get; set; }
        public StatResponse RatioStatDetail { get; set; }
        public decimal TotalPoint { get; set; }
        public decimal RatioTotalPoint { get; set; }
        public decimal OnePointRatio { get; set; }
        public decimal TwoPointRatio { get; set; }
        public int MatchCount { get; set; }
        public int TwoPointMatchCount { get; set; }

        public List<string> MatchStatus { get; set; } //W:Win L:Loose D:Draw

        public decimal WinRatio { get; set; }
        public decimal LooseRatio { get; set; }
    }
}