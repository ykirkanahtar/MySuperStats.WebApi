using System.Threading.Tasks;
using CustomFramework.Data.Repositories;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using MySuperStats.WebApi.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore.Query;
using MySuperStats.Contracts.Responses;
using MySuperStats.Contracts.Enums;

namespace MySuperStats.WebApi.Data.Repositories
{
    public class FootballStatRepository : BaseRepository<FootballStat, int>, IFootballStatRepository
    {
        const int Take = 5;
        private static readonly Func<IQueryable<FootballStat>, IIncludableQueryable<FootballStat, object>> includes = source => source.Include(p => p.Match);

        public FootballStatRepository(DbContext dbContext) : base(dbContext, includes)
        {

        }

        public async Task<FootballStat> GetByMatchIdTeamIdAndPlayerId(int matchId, int teamId, int playerId)
        {
            var predicate = PredicateBuilder.New<FootballStat>();
            predicate = predicate.And(p => p.MatchId == matchId);
            predicate = predicate.And(p => p.TeamId == teamId);
            predicate = predicate.And(p => p.PlayerId == playerId);

            return await GetAll(predicate: predicate)
                .FirstOrDefaultAsync();
        }

        public async Task<decimal> GetTeamScoreByMatchIdAndTeamId(int matchId, int teamId)
        {
            return await (from p in GetAll()
                          where p.MatchId == matchId
                                && p.TeamId == teamId
                          select p.Goal).FirstOrDefaultAsync();
        }

        public async Task<IList<FootballStat>> GetAllByMatchIdAsync(int matchId)
        {
            return await GetAll(predicate: p => p.MatchId == matchId).ToListAsync();
        }

        public async Task<IList<FootballStat>> GetAllByMatchGroupIdAndPlayerIdAsync(int matchGroupId, int playerId)
        {
            return await GetAll(predicate: p => p.PlayerId == playerId && p.Match.MatchGroupId == matchGroupId).ToListAsync();
        }

        public async Task<IList<FootballStat>> GetAllByMatchGroupIdAsync(int matchGroupId)
        {
            return await GetAll(predicate: p => p.Match.MatchGroupId == matchGroupId).ToListAsync();
        }

        public List<StatisticDetail> GetTopGoalsStat(IList<Player> players, IList<FootballStat> stats)
        {
            return (from a in
                     ((from p in stats
                       where players.Contains(p.Player)
                       group p by p.PlayerId into g
                       let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                       select new
                       {
                           PlayerId = g.Key,
                           Value = g.Sum(s => s.Goal),
                           MatchCount = matchCount
                       }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount).ThenBy(p => p.MatchCount)
                         .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetTopGoalsPerMatchStat(IList<Player> players, IList<FootballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = matchCount > 0 ? (g.Sum(s => s.Goal)) / matchCount : 0,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                    .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetOwnGoalStat(IList<Player> players, IList<FootballStat> stats)
        {
            return (from a in
                     ((from p in stats
                       where players.Contains(p.Player)
                       group p by p.PlayerId into g
                       let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                       select new
                       {
                           PlayerId = g.Key,
                           Value = g.Sum(s => s.OwnGoal),
                           MatchCount = matchCount
                       }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount).ThenBy(p => p.MatchCount)
                         .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetOwnGoalPerMatchStat(IList<Player> players, IList<FootballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = matchCount > 0 ? (g.Sum(s => s.OwnGoal)) / matchCount : 0,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                    .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetPenaltyScoreStat(IList<Player> players, IList<FootballStat> stats)
        {
            return (from a in
                     ((from p in stats
                       where players.Contains(p.Player)
                       group p by p.PlayerId into g
                       let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                       select new
                       {
                           PlayerId = g.Key,
                           Value = g.Sum(s => s.PenaltyScore),
                           MatchCount = matchCount
                       }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount).ThenBy(p => p.MatchCount)
                         .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetPenaltyScorePerMatchStat(IList<Player> players, IList<FootballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = matchCount > 0 ? (g.Sum(s => s.PenaltyScore)) / matchCount : 0,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                    .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetMissedPenaltyStat(IList<Player> players, IList<FootballStat> stats)
        {
            return (from a in
                     ((from p in stats
                       where players.Contains(p.Player)
                       group p by p.PlayerId into g
                       let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                       select new
                       {
                           PlayerId = g.Key,
                           Value = g.Sum(s => s.MissedPenalty),
                           MatchCount = matchCount
                       }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount).ThenBy(p => p.MatchCount)
                         .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetMissedPenaltyPerMatchStat(IList<Player> players, IList<FootballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = matchCount > 0 ? (g.Sum(s => s.MissedPenalty)) / matchCount : 0,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                    .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetAssistStat(IList<Player> players, IList<FootballStat> stats)
        {
            return (from a in
                     ((from p in stats
                       where players.Contains(p.Player)
                       group p by p.PlayerId into g
                       let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                       select new
                       {
                           PlayerId = g.Key,
                           Value = g.Sum(s => s.Assist),
                           MatchCount = matchCount
                       }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount).ThenBy(p => p.MatchCount)
                         .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetAssistPerMatchStat(IList<Player> players, IList<FootballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = matchCount > 0 ? (g.Sum(s => s.Assist)) / matchCount : 0,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                    .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetSaveGoalStat(IList<Player> players, IList<FootballStat> stats)
        {
            return (from a in
                     ((from p in stats
                       where players.Contains(p.Player)
                       group p by p.PlayerId into g
                       let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                       select new
                       {
                           PlayerId = g.Key,
                           Value = g.Sum(s => s.SaveGoal),
                           MatchCount = matchCount
                       }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount).ThenBy(p => p.MatchCount)
                         .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();        }

        public List<StatisticDetail> GetSaveGoalPerMatchStat(IList<Player> players, IList<FootballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = matchCount > 0 ? (g.Sum(s => s.SaveGoal)) / matchCount : 0,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                    .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetConcedeGoalStat(IList<Player> players, IList<FootballStat> stats)
        {
            return (from a in
                     ((from p in stats
                       where players.Contains(p.Player)
                       group p by p.PlayerId into g
                       let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                       select new
                       {
                           PlayerId = g.Key,
                           Value = g.Sum(s => s.ConcedeGoal),
                           MatchCount = matchCount
                       }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount).ThenBy(p => p.MatchCount)
                         .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();        }

        public List<StatisticDetail> GetConcedeGoalPerMatchStat(IList<Player> players, IList<FootballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = matchCount > 0 ? (g.Sum(s => s.ConcedeGoal)) / matchCount : 0,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                    .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetWinsStat(IList<Player> players, List<MatchResultByPlayer> matchResultByPlayers)
        {
            return (from a in
                     ((from p in matchResultByPlayers
                       where players.Contains(p.Player) && p.MatchResult != MatchResult.BothOfTeam
                       group p by p.Player.Id into g
                       let matchCount = (from a in matchResultByPlayers where a.Player.Id == g.Key && a.MatchResult != MatchResult.BothOfTeam select a.MatchResult).Count()
                       select new
                       {
                           PlayerId = g.Key,
                           Value = g.Count(s => s.MatchResult == MatchResult.Win),
                           MatchCount = matchCount
                       }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                         .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = a.Value,
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetWinRatioStat(IList<Player> players, List<MatchResultByPlayer> matchResultByPlayers)
        {
            return (from a in
                    ((from p in matchResultByPlayers
                      where players.Contains(p.Player) && p.MatchResult != MatchResult.BothOfTeam
                      group p by p.Player.Id into g
                      let matchCount = (from a in matchResultByPlayers where a.Player.Id == g.Key && a.MatchResult != MatchResult.BothOfTeam select a.MatchResult).Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = g.Count() > 0 ? (g.Count(s => s.MatchResult == MatchResult.Win) * 100) / g.Count() : 0,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = a.Value,
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetLoosesStat(IList<Player> players, List<MatchResultByPlayer> matchResultByPlayers)
        {
            return (from a in
                    ((from p in matchResultByPlayers
                      where players.Contains(p.Player) && p.MatchResult != MatchResult.BothOfTeam
                      group p by p.Player.Id into g
                      let matchCount = (from a in matchResultByPlayers where a.Player.Id == g.Key && a.MatchResult != MatchResult.BothOfTeam select a.MatchResult).Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = g.Count(s => s.MatchResult == MatchResult.Loose),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = a.Value,
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetLooseRatioStat(IList<Player> players, List<MatchResultByPlayer> matchResultByPlayers)
        {
            return (from a in
                    ((from p in matchResultByPlayers
                      where players.Contains(p.Player) && p.MatchResult != MatchResult.BothOfTeam
                      group p by p.Player.Id into g
                      let matchCount = (from a in matchResultByPlayers where a.Player.Id == g.Key && a.MatchResult != MatchResult.BothOfTeam select a.MatchResult).Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = g.Count() > 0 ? (g.Count(s => s.MatchResult == MatchResult.Loose) * 100) / g.Count() : 0,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        FirstNameLastName = $"{pl.FirstName} {pl.LastName}",
                        Value = a.Value,
                        GameCount = a.MatchCount
                    }).ToList();
        }
    }
}