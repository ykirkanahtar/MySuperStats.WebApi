using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.Data.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using MySuperStats.Contracts;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Responses;
using Remotion.Linq.Clauses;

namespace MySuperStats.WebApi.Data.Repositories
{
    public class BasketballStatRepository : BaseRepository<BasketballStat, int>, IBasketballStatRepository
    {
        const int Take = 5;

        //private static readonly Expression<Func<Stat, object>>[] IncludeProperties = { p => p.Player, p => p.Match, p => p.Team };

        //public StatRepository(DbContext dbContext) : base(dbContext, IncludeProperties)
        //{

        //}

        public BasketballStatRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<BasketballStat> GetByMatchIdTeamIdAndPlayerId(int matchId, int teamId, int playerId)
        {
            var predicate = PredicateBuilder.New<BasketballStat>();
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
                          select p.OnePoint + p.TwoPoint * 2).FirstOrDefaultAsync();
        }

        public async Task<ICustomList<BasketballStat>> GetAllByMatchIdAsync(int matchId)
        {
            return await GetAll(predicate: p => p.MatchId == matchId).ToCustomList();
        }

        public async Task<ICustomList<BasketballStat>> GetAllByPlayerIdAsync(int playerId)
        {
            return await GetAll(predicate: p => p.PlayerId == playerId).ToCustomList();
        }

        public async Task<ICustomList<BasketballStat>> GetAllAsync()
        {
            return await GetAll().Include(p => p.Match).ToCustomList();
        }

        public List<StatisticDetail> GetTopPointsStat(IList<Player> players, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = g.Sum(s => s.OnePoint + s.TwoPoint * 2),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetTopPointsPerMatchStat(IList<Player> players, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = (g.Sum(s => s.OnePoint + s.TwoPoint * 2)) / matchCount,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                    .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();

        }

        public List<StatisticDetail> GetTopOnePointStat(IList<Player> players, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = g.Sum(s => s.OnePoint),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetTopOnePointPerMatchStat(IList<Player> players, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = (g.Sum(s => s.OnePoint)) / matchCount,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetOnePointRatioStat(IList<Player> players, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = (g.Sum(s => s.OnePoint) * 100) / g.Sum(s => s.OnePoint + s.MissingOnePoint),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetTwoPointStat(IList<Player> players, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                            && p.Match.MatchDate >= ReleaseDates.TwoPointReleasedate
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key && a.Match.MatchDate >= ReleaseDates.TwoPointReleasedate select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = g.Sum(s => s.TwoPoint),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetTwoPointPerMatchStat(IList<Player> players, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                            && p.Match.MatchDate >= ReleaseDates.TwoPointReleasedate
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key && a.Match.MatchDate >= ReleaseDates.TwoPointReleasedate select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = (g.Sum(s => s.TwoPoint)) / matchCount,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetTwoPointRatioStat(IList<Player> players, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                            && p.Match.MatchDate >= ReleaseDates.TwoPointReleasedate
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key && a.Match.MatchDate >= ReleaseDates.TwoPointReleasedate select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = (g.Sum(s => s.TwoPoint) * 100) / g.Sum(s => s.TwoPoint + s.MissingOnePoint),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetReboundStat(IList<Player> players, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = g.Sum(s => s.Rebound),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetReboundPerMatchStat(IList<Player> players, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = (g.Sum(s => s.Rebound)) / matchCount,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetStealStat(IList<Player> players, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = g.Sum(s => s.StealBall),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetStealPerMatchStat(IList<Player> players, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = (g.Sum(s => s.StealBall)) / matchCount,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetTurnoverStat(IList<Player> players, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = g.Sum(s => s.LooseBall),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetTurnoverPerMatchStat(IList<Player> players, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = (g.Sum(s => s.LooseBall)) / matchCount,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetAssistStat(IList<Player> players, IList<BasketballStat> stats)
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
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetAssistPerMatchStat(IList<Player> players, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = (g.Sum(s => s.Assist)) / matchCount,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetInterruptStat(IList<Player> players, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = g.Sum(s => s.Interrupt),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetInterruptPerMatchStat(IList<Player> players, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where players.Contains(p.Player)
                      group p by p.PlayerId into g
                      let matchCount = (from a in stats where a.PlayerId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          PlayerId = g.Key,
                          Value = (g.Sum(s => s.Interrupt)) / matchCount,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
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
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
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
                          Value = (g.Count(s => s.MatchResult == MatchResult.Win) * 100) / g.Count(),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
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
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
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
                          Value = (g.Count(s => s.MatchResult == MatchResult.Loose) * 100) / g.Count(),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in players on a.PlayerId equals pl.Id
                    select new StatisticDetail
                    {
                        PlayerId = pl.Id,
                        PlayerName = $"{pl.Name} {pl.Surname}",
                        Value = a.Value,
                        GameCount = a.MatchCount
                    }).ToList();
        }
    }
}