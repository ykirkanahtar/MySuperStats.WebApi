using CustomFramework.Data.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MySuperStats.WebApi.Models
{
    public class Team : BaseModel<int>
    {
        public string TeamName { get; set; }
        public string Color { get; set; }

        [JsonIgnore]
        public virtual ICollection<Match> HomeMatches { get; set; }

        [JsonIgnore]
        public virtual ICollection<Match> AwayMatches { get; set; }

        [JsonIgnore]
        public virtual ICollection<BasketballStat> BasketballStats { get; set; }

        [JsonIgnore]
        public virtual ICollection<FootballStat> FootballStats { get; set; }

        [JsonIgnore]
        public virtual ICollection<MatchGroupTeam> MatchGroupTeams { get; set; }
    }
}
