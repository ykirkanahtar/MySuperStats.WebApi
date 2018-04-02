using BasketballStats.Contracts.Responses;

namespace BasketballStats.WebSite.Models
{
    public class PlayerStat
    {
        public PlayerResponse Player { get; set; }
        public StatResponse Stat { get; set; }
    }
}