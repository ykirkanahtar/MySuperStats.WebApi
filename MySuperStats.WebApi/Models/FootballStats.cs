using CustomFramework.Data.Models;

namespace MySuperStats.WebApi.Models
{
    public class FootballStat : BaseModel<int>
    {
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }

        public decimal Goal { get; set; }
        public decimal OwnGoal { get; set; }
        public decimal PenaltyScore { get; set; }
        public decimal MissedPenalty { get; set; }
        public decimal Assist { get; set; }
        public decimal SaveGoal { get; set; }
        public decimal ConcedeGoal { get; set; }

        public virtual Match Match { get; set; }
        public virtual Team Team { get; set; }
        public virtual Player Player { get; set; }
    }
}