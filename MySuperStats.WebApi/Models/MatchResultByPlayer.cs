using MySuperStats.Contracts.Enums;

namespace MySuperStats.WebApi.Models
{
    public class MatchResultByPlayer
    {
        public MatchResultByPlayer(Player player, MatchResult matchResult)
        {
            Player = player;
            MatchResult = matchResult;
        }

        public Player Player { get; set; }
        public MatchResult MatchResult { get; set; }  //Enum
    }
}