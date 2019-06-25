using MySuperStats.Contracts.Enums;

namespace MySuperStats.WebApi.Models
{
    public class MatchResultByUser
    {
        public MatchResultByUser(User user, MatchResult matchResult)
        {
            User = user;
            MatchResult = matchResult;
        }

        public User User { get; set; }
        public MatchResult MatchResult { get; set; }  //Enum
    }
}