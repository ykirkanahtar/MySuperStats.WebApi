namespace MySuperStats.Contracts.Responses
{
    public class FootballStatResponse
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }

        public decimal Goal { get; set; }
        public decimal? OwnGoal { get; set; }
        public decimal? PenaltyScore { get; set; }
        public decimal? MissedPenalty { get; set; }
        public decimal? Assist { get; set; }
        public decimal? SaveGoal { get; set; }
        public decimal? ConcedeGoal { get; set; }

        public virtual BaseMatchResponse Match { get; set; }
        public virtual BaseTeamResponse Team { get; set; }
        public virtual PlayerResponse Player { get; set; }

        public FootballStatResponseForUIGrid GetStatsForUI()
        {
            return new FootballStatResponseForUIGrid
            {
                Goal =  Goal.ToString(),
                OwnGoal = OwnGoal == null ? string.Empty : decimal.Truncate((decimal)OwnGoal).ToString(),
                PenaltyScore = PenaltyScore == null ? string.Empty : decimal.Truncate((decimal)PenaltyScore).ToString(),
                MissedPenalty = MissedPenalty == null ? string.Empty : decimal.Truncate((decimal)MissedPenalty).ToString(),
                Assist = Assist == null ? string.Empty : decimal.Truncate((decimal)Assist).ToString(),
                SaveGoal = SaveGoal == null ? string.Empty : decimal.Truncate((decimal)SaveGoal).ToString(),
                ConcedeGoal = ConcedeGoal == null ? string.Empty : decimal.Truncate((decimal)ConcedeGoal).ToString(),
            };
        }        
    }

}