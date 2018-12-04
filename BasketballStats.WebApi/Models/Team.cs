using CustomFramework.Data.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BasketballStats.WebApi.Models
{
    public class Team : BaseModel<int>
    {
        public string Name { get; set; }
        public string Color { get; set; }

        [JsonIgnore]
        public virtual ICollection<Match> HomeMatches { get; set; }

        [JsonIgnore]
        public virtual ICollection<Match> AwayMatches { get; set; }

        [JsonIgnore]
        public virtual ICollection<Stat> Stats { get; set; }
    }
}
