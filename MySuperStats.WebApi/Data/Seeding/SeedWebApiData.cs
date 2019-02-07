using System.Collections.Generic;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.Utils;
using Microsoft.EntityFrameworkCore;

namespace MySuperStats.WebApi.Data.Seeding
{
    public class SeedWebApiData
    {
        public SeedWebApiData()
        {
            Matches = new List<Match>();
            Teams = new List<Team>();
            Players = new List<Player>();
            BasketballStats = new List<BasketballStat>();
        }

        public IList<Match> Matches { get; set; }
        public IList<Team> Teams { get; set; }
        public IList<Player> Players { get; set; }
        public IList<BasketballStat> BasketballStats { get; set; }

        public void SeedMatchData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<Match, int>(modelBuilder, Matches, 1);
        }

        public void SeedTeamData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<Team, int>(modelBuilder, Teams, 1);
        }

        public void SeedPlayerData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<Player, int>(modelBuilder, Players, 1);
        }

        public void SeedStatData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<BasketballStat, int>(modelBuilder, BasketballStats, 1);
        }

        public void SeedAll(ModelBuilder modelBuilder)
        {
            SeedMatchData(modelBuilder);
            SeedTeamData(modelBuilder);
            SeedPlayerData(modelBuilder);
            SeedStatData(modelBuilder);
        }
    }
}