namespace MySuperStats.Contracts.Requests
{
    public class FootballStatRequest
    {
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int UserId { get; set; }

        public decimal Goal { get; set; }
        public decimal OwnGoal { get; set; }
        public decimal PenaltyScore { get; set; }
        public decimal MissedPenalty { get; set; }
        public decimal Assist { get; set; }
        public decimal SaveGoal { get; set; }
        public decimal ConcedeGoal { get; set; }

    }
}