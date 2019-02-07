using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySuperStats.WebApi.Models
{
    public class MatchDetailStats
    {
        public MatchDetailStats()
        {
            HomeTeamStats = new TeamStats();
            AwayTeamStats = new TeamStats();
        }

        public DateTime MatchDate { get; set; }
        public int MatchOrder { get; set; }
        public string VideoLink { get; set; }
        public TeamStats HomeTeamStats { get; set; }
        public TeamStats AwayTeamStats { get; set; }
    }

    public class TeamStats
    {
        public TeamStats()
        {
            PlayerStats = new List<PlayerStats>();
        }

        public Team Team { get; set; }
        public decimal AgeRatio { get; set; }
        public List<PlayerStats> PlayerStats { get; set; }
    }

    public class PlayerStats
    {
        public Player Player { get; set; }
        public Stat Stat { get; set; }
    }
}
