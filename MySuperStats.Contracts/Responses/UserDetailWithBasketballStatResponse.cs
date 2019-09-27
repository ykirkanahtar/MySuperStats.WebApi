using System;
using System.Collections.Generic;
using System.Linq;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Utils;

namespace MySuperStats.Contracts.Responses
{
    public class UserDetailWithBasketballStatResponse
    {
        public UserDetailWithBasketballStatResponse()
        {
            User = new UserResponse();
            PerMatchStats = new BasketballStatResponse();
            TotalStats = new BasketballStatResponse();
            RatioTable = new BasketballRatioTable(0, 0);
            MatchForms = new List<MatchResult>();
            WinLooseTable = new WinLooseTable(0, 0, 0, 0);
            Matches = new List<BaseMatchResponse>();
        }

        public UserResponse User { get; set; }
        public BasketballStatResponse PerMatchStats { get; set; }
        public BasketballStatResponse TotalStats { get; set; }
        public BasketballRatioTable RatioTable { get; set; }
        public List<MatchResult> MatchForms { get; set; }
        public WinLooseTable WinLooseTable { get; set; }
        public List<BaseMatchResponse> Matches { get; set; }
    }
}
