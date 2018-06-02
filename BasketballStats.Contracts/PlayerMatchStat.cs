using BasketballStats.Contracts.Responses;

namespace BasketballStats.Contracts
{
    public class PlayerMatchStat
    {
        public PlayerResponse Player { get; set; }
        public StatResponse Stat { get; set; }
    }
}
