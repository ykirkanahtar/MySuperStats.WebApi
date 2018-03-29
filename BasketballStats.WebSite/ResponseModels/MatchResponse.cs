using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BasketballStats.WebSite.ResponseModels
{
    public class MatchResponse
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public int Order { get; set; }
        public int DurationInMinutes { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public string VideoLink { get; set; }

        public TeamResponse HomeTeam { get; set; }
        public TeamResponse AwayTeam { get; set; }

        [JsonIgnore]
        public IList<StatResponse> Stats { get; set; }
    }
}
