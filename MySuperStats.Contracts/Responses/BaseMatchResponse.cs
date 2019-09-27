using System;

namespace MySuperStats.Contracts.Responses
{
    public class BaseMatchResponse
    {
        public int Id { get; set; }
        public int MatchGroupId { get; set; }
        public DateTime MatchDate { get; set; }
        public int Order { get; set; }
        public int DurationInMinutes { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public decimal HomeTeamScore { get; set; }
        public decimal AwayTeamScore { get; set; }
        public string VideoLink { get; set; }
    }
}

