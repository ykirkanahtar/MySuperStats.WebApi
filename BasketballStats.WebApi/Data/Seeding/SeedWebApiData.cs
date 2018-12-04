using System.Collections.Generic;
using BasketballStats.WebApi.Models;
using CustomFramework.Data.Utils;
using Microsoft.EntityFrameworkCore;

namespace BasketballStats.WebApi.Data.Seeding
{
    public class SeedWebApiData
    {
        public SeedWebApiData()
        {
            Matches = new List<Match>();
            Teams = new List<Team>();
            Players = new List<Player>();
            Stats = new List<Stat>();
        }

        public IList<Match> Matches { get; set; }
        public IList<Team> Teams { get; set; }
        public IList<Player> Players { get; set; }
        public IList<Stat> Stats { get; set; }

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
            SeedDataUtil.SeedTData<Stat, int>(modelBuilder, Stats, 1);
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