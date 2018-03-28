using System.Collections.Generic;
using Newtonsoft.Json;

namespace BasketballStats.WebSite.ResponseModels
{
    public class TeamResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        [JsonIgnore]
        public IList<MatchResponse> HomeMatches { get; set; }
        [JsonIgnore]
        public IList<MatchResponse> AwayMatches { get; set; }
        [JsonIgnore]
        public IList<StatResponse> Stats { get; set; }
    }
}
