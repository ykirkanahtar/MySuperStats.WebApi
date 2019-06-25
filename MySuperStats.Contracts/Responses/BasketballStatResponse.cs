﻿namespace MySuperStats.Contracts.Responses
{
    public class BasketballStatResponse
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int UserId { get; set; }

        public decimal OnePoint { get; set; }
        public decimal TwoPoint { get; set; }
        public decimal MissingOnePoint { get; set; }
        public decimal MissingTwoPoint { get; set; }
        public decimal Rebound { get; set; }
        public decimal StealBall { get; set; }
        public decimal LooseBall { get; set; }
        public decimal Assist { get; set; }
        public decimal Interrupt { get; set; }

        public virtual MatchResponse Match { get; set; }
        public virtual TeamResponse Team { get; set; }
        public virtual UserResponse User { get; set; }
    }
}
