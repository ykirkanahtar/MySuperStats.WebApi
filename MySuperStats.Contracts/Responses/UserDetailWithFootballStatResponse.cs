using System.Collections.Generic;
using MySuperStats.Contracts.Enums;

namespace MySuperStats.Contracts.Responses
{
    public class UserDetailWithFootballStatResponse
    {
        public UserDetailWithFootballStatResponse()
        {
            User = new UserResponse();
            Player = new PlayerResponse();
            PerMatchStats = new FootballStatResponse();
            TotalStats = new FootballStatResponse();
            MatchForms = new List<MatchResult>();
            WinLooseTable = new WinLooseTable(0, 0, 0, 0);
            Matches = new List<BaseMatchResponse>();
        }

        public UserResponse User { get; set; }
        public PlayerResponse Player { get; set; }
        public FootballStatResponse PerMatchStats { get; set; }
        public FootballStatResponse TotalStats { get; set; }
        public List<MatchResult> MatchForms { get; set; }
        public WinLooseTable WinLooseTable { get; set; }
        public List<BaseMatchResponse> Matches { get; set; }
    }
}
