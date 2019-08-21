namespace MySuperStats.Contracts.Responses
{
    public class BasketballStatResponse
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int UserId { get; set; }

        public decimal OnePoint { get; set; }
        public decimal? TwoPoint { get; set; }
        public decimal? MissingOnePoint { get; set; }
        public decimal? MissingTwoPoint { get; set; }
        public decimal? Rebound { get; set; }
        public decimal? StealBall { get; set; }
        public decimal? LooseBall { get; set; }
        public decimal? Assist { get; set; }
        public decimal? Interrupt { get; set; }

        public virtual MatchResponse Match { get; set; }
        public virtual TeamResponse Team { get; set; }
        public virtual UserResponse User { get; set; }

        public BasketballStatResponseForUIGrid GetStatsForUI()
        {
            return new BasketballStatResponseForUIGrid
            {
                OnePoint = $"{decimal.Truncate(OnePoint)} / {decimal.Truncate(OnePoint + MissingOnePoint ?? 0)}",
                TwoPoint = TwoPoint == null ? string.Empty : $"{decimal.Truncate((decimal)TwoPoint)} / {decimal.Truncate(TwoPoint + MissingTwoPoint ?? 0)}",
                TotalPoint = decimal.Truncate(OnePoint + (TwoPoint ?? 0) * 2).ToString(),
                Rebound = Rebound == null ? string.Empty : decimal.Truncate((decimal)Rebound).ToString(),
                StealBall = StealBall == null ? string.Empty : decimal.Truncate((decimal)StealBall).ToString(),
                LooseBall = LooseBall == null ? string.Empty : decimal.Truncate((decimal)LooseBall).ToString(),
                Assist = Assist == null ? string.Empty : decimal.Truncate((decimal)Assist).ToString(),
                Interrupt = Interrupt == null ? string.Empty : decimal.Truncate((decimal)Interrupt).ToString(),
            };
        }
    }
}
