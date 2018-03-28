using Newtonsoft.Json;

namespace BasketballStats.WebSite.ResponseModels
{
    public class StatResponse
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }

        public int OnePoint { get; set; }
        public int TwoPoint { get; set; }
        public int MissingOnePoint { get; set; }
        public int MissingTwoPoint { get; set; }
        public int Rebound { get; set; }
        public int StealBall { get; set; }
        public int LooseBall { get; set; }
        public int Assist { get; set; }
        public int Interrupt { get; set; }

        [JsonIgnore]
        public MatchResponse Match { get; set; }
        [JsonIgnore]
        public TeamResponse Team { get; set; }
        [JsonIgnore]
        public PlayerResponse Player { get; set; }
    }
}
