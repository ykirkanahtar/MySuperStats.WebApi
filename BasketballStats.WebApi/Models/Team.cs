using System.Collections.Generic;
using BasketballStats.WebApi.Data;
using Newtonsoft.Json;

namespace BasketballStats.WebApi.Models
{
    public class Team : BaseModel<int>
    {
        public string Name { get; set; }
        public string Color { get; set; }

        [JsonIgnore]
        public IList<Match> HomeMatches { get; set; }
        [JsonIgnore]
        public IList<Match> AwayMatches { get; set; }
        [JsonIgnore]
        public IList<Stat> Stats { get; set; }

    }
}
