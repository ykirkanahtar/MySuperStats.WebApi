using System.Collections.Generic;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Responses;

namespace MySuperStats.WebApi.Models
{
    public class UserDetailWithFootballStat
    {
        public UserDetailWithFootballStat()
        {
            Player = new Player();
            FootballStats = new List<FootballStat>();
            PerMatchStats = new FootballStat();
            TotalStats = new FootballStat();
            MatchForms = new List<MatchResult>();
            Matches = new List<Match>();
        }
        public Player Player { get; set; }
        public List<FootballStat> FootballStats { get; set; }
        public FootballStat PerMatchStats { get; set; }
        public FootballStat TotalStats { get; set; }
        public List<MatchResult> MatchForms { get; set; }
        public WinLooseTable WinLooseTable { get; set; }
        public List<Match> Matches { get; set; }
    }
}
