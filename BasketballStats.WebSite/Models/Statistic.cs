using System.Collections.Generic;

namespace BasketballStats.WebSite.Models
{
    public class Statistic
    {
        public Statistic()
        {
            TotalPoints = new List<TopResult>();

            TotalOnePoints = new List<TopResult>();
            TotalTwoPoints = new List<TopResult>();
            TotalRebounds = new List<TopResult>();
            TotalStealBalls = new List<TopResult>();
            TotalLooseBalls = new List<TopResult>();
            TotalAsists = new List<TopResult>();
            TotalInterrupts = new List<TopResult>();

            RatioTotalPoints = new List<TopResult>();
            RatioOnePoints = new List<TopResult>();
            RatioTwoPoints = new List<TopResult>();
            RatioRebounds = new List<TopResult>();
            RatioStealBalls = new List<TopResult>();
            RatioLooseBalls = new List<TopResult>();
            RatioAsists = new List<TopResult>();
            RatioInterrupts = new List<TopResult>();

            OnePointRatio = new List<TopResult>();
            TwoPointRatio = new List<TopResult>();
        }

        public List<TopResult> TotalPoints { get; set; }
        public List<TopResult> TotalOnePoints { get; set; }
        public List<TopResult> TotalTwoPoints { get; set; }
        public List<TopResult> TotalRebounds { get; set; }
        public List<TopResult> TotalStealBalls { get; set; }
        public List<TopResult> TotalLooseBalls { get; set; }
        public List<TopResult> TotalAsists { get; set; }
        public List<TopResult> TotalInterrupts { get; set; }
        public List<TopResult> TotalWins { get; set; }
        public List<TopResult> TotalLoose { get; set; }

        public List<TopResult> RatioTotalPoints { get; set; }
        public List<TopResult> RatioOnePoints { get; set; }
        public List<TopResult> RatioTwoPoints { get; set; }
        public List<TopResult> RatioRebounds { get; set; }
        public List<TopResult> RatioStealBalls { get; set; }
        public List<TopResult> RatioLooseBalls { get; set; }
        public List<TopResult> RatioAsists { get; set; }
        public List<TopResult> RatioInterrupts { get; set; }

        public List<TopResult> RatioWins { get; set; }
        public List<TopResult> RatioLoose { get; set; }


        public List<TopResult> OnePointRatio { get; set; }
        public List<TopResult> TwoPointRatio { get; set; }
    }
}
