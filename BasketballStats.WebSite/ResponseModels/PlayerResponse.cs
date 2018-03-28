using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BasketballStats.WebSite.ResponseModels

{
    public class PlayerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

        [JsonIgnore]
        public IList<StatResponse> Stats { get; set; }
    }
}
