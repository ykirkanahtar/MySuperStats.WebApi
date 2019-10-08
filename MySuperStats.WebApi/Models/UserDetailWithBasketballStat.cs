using System.Collections.Generic;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Responses;

namespace MySuperStats.WebApi.Models
{
    public class UserDetailWithBasketballStat
    {
        public UserDetailWithBasketballStat()
        {
            Player = new Player();
            PerMatchStats = new BasketballStat();
            TotalStats = new BasketballStat();
            MatchForms = new List<MatchResult>();
            Matches = new List<Match>();
        }
        public Player Player { get; set; }
        public BasketballStat PerMatchStats { get; set; }
        public BasketballStat TotalStats { get; set; }
        public BasketballRatioTable RatioTable { get; set; }
        public List<MatchResult> MatchForms { get; set; }
        public WinLooseTable WinLooseTable { get; set; }
        public List<Match> Matches { get; set; }
    }
}
