using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace MySuperStats.Contracts.Responses
{
    public class MatchResponse
    {
        public MatchResponse()
        {
            HomeTeam = new TeamResponse();
            AwayTeam = new TeamResponse();
            BasketballStats = new Collection<BasketballStatResponse>();
            FootballStats = new Collection<FootballStatResponse>();
        }

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

        public virtual MatchGroupResponse MatchGroup { get; set; }
        public virtual TeamResponse HomeTeam { get; set; }
        public virtual TeamResponse AwayTeam { get; set; }
        public virtual ICollection<BasketballStatResponse> BasketballStats { get; set; }
        public virtual ICollection<FootballStatResponse> FootballStats { get; set; }
    }
}

