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
using Microsoft.EntityFrameworkCore.Query;

namespace MySuperStats.WebApi.Data.Repositories
{
    public class BasketballStatRepository : BaseRepository<BasketballStat, int>, IBasketballStatRepository
    {
        const int Take = 5;

        private static readonly Func<IQueryable<BasketballStat>, IIncludableQueryable<BasketballStat, object>> includes = source => source.Include(p => p.Match);

        public BasketballStatRepository(DbContext dbContext) : base(dbContext, includes)
        {

        }

        public async Task<BasketballStat> GetByMatchIdTeamIdAndUserId(int matchId, int teamId, int userId)
        {
            var predicate = PredicateBuilder.New<BasketballStat>();
            predicate = predicate.And(p => p.MatchId == matchId);
            predicate = predicate.And(p => p.TeamId == teamId);
            predicate = predicate.And(p => p.UserId == userId);

            return await GetAll(predicate: predicate)
                .FirstOrDefaultAsync();
        }

        public async Task<decimal> GetTeamScoreByMatchIdAndTeamId(int matchId, int teamId)
        {
            return await (from p in GetAll()
                          where p.MatchId == matchId
                                && p.TeamId == teamId
                          select p.OnePoint + p.TwoPoint ?? 0 * 2).FirstOrDefaultAsync();
        }

        public async Task<IList<BasketballStat>> GetAllByMatchIdAsync(int matchId)
        {
            return await GetAll(predicate: p => p.MatchId == matchId).ToListAsync();
        }

        public async Task<IList<BasketballStat>> GetAllByMatchGroupIdAndUserIdAsync(int matchGroupId, int userId)
        {
            return await GetAll(predicate: p => p.UserId == userId && p.Match.MatchGroupId == matchGroupId).ToListAsync();
        }

        public async Task<IList<BasketballStat>> GetAllByMatchGroupIdAsync(int matchGroupId)
        {
            return await GetAll(predicate: p => p.Match.MatchGroupId == matchGroupId).ToListAsync();
        }

        public List<StatisticDetail> GetTopPointsStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                     ((from p in stats
                       where users.Contains(p.User)
                       group p by p.UserId into g
                       let matchCount = (from a in stats where a.UserId == g.Key select a.MatchId).Distinct().Count()
                       select new
                       {
                           UserId = g.Key,
                           Value = g.Sum(s => s.OnePoint + s.TwoPoint * 2),
                           MatchCount = matchCount
                       }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount).ThenBy(p => p.MatchCount)
                         .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetTopPointsPerMatchStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where users.Contains(p.User)
                      group p by p.UserId into g
                      let matchCount = (from a in stats where a.UserId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = (g.Sum(s => s.OnePoint + s.TwoPoint * 2)) / matchCount,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                    .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();

        }

        public List<StatisticDetail> GetTopOnePointStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where users.Contains(p.User)
                      group p by p.UserId into g
                      let matchCount = (from a in stats where a.UserId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = g.Sum(s => s.OnePoint),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetTopOnePointPerMatchStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where users.Contains(p.User)
                      group p by p.UserId into g
                      let matchCount = (from a in stats where a.UserId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = (g.Sum(s => s.OnePoint)) / matchCount,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round(a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetOnePointRatioStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where users.Contains(p.User)
                      group p by p.UserId into g
                      let matchCount = (from a in stats where a.UserId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = (g.Sum(s => s.OnePoint) * 100) / g.Sum(s => s.OnePoint + s.MissingOnePoint),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetTwoPointStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where users.Contains(p.User)
                            && p.Match.MatchDate >= ReleaseDates.TwoPointReleasedate
                      group p by p.UserId into g
                      let matchCount = (from a in stats where a.UserId == g.Key && a.Match.MatchDate >= ReleaseDates.TwoPointReleasedate select a.MatchId).Distinct().Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = g.Sum(s => s.TwoPoint),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetTwoPointPerMatchStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where users.Contains(p.User)
                            && p.Match.MatchDate >= ReleaseDates.TwoPointReleasedate
                      group p by p.UserId into g
                      let matchCount = (from a in stats where a.UserId == g.Key && a.Match.MatchDate >= ReleaseDates.TwoPointReleasedate select a.MatchId).Distinct().Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = (g.Sum(s => s.TwoPoint)) / matchCount,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetTwoPointRatioStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where users.Contains(p.User)
                            && p.Match.MatchDate >= ReleaseDates.TwoPointReleasedate
                      group p by p.UserId into g
                      let matchCount = (from a in stats where a.UserId == g.Key && a.Match.MatchDate >= ReleaseDates.TwoPointReleasedate select a.MatchId).Distinct().Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = (g.Sum(s => s.TwoPoint) * 100) / g.Sum(s => s.TwoPoint + s.MissingOnePoint),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetReboundStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where users.Contains(p.User)
                      group p by p.UserId into g
                      let matchCount = (from a in stats where a.UserId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = g.Sum(s => s.Rebound),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetReboundPerMatchStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where users.Contains(p.User)
                      group p by p.UserId into g
                      let matchCount = (from a in stats where a.UserId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = (g.Sum(s => s.Rebound)) / matchCount,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetStealStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where users.Contains(p.User)
                      group p by p.UserId into g
                      let matchCount = (from a in stats where a.UserId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = g.Sum(s => s.StealBall),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetStealPerMatchStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where users.Contains(p.User)
                      group p by p.UserId into g
                      let matchCount = (from a in stats where a.UserId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = (g.Sum(s => s.StealBall)) / matchCount,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetTurnoverStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where users.Contains(p.User)
                      group p by p.UserId into g
                      let matchCount = (from a in stats where a.UserId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = g.Sum(s => s.LooseBall),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetTurnoverPerMatchStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where users.Contains(p.User)
                      group p by p.UserId into g
                      let matchCount = (from a in stats where a.UserId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = (g.Sum(s => s.LooseBall)) / matchCount,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetAssistStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where users.Contains(p.User)
                      group p by p.UserId into g
                      let matchCount = (from a in stats where a.UserId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = g.Sum(s => s.Assist),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetAssistPerMatchStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where users.Contains(p.User)
                      group p by p.UserId into g
                      let matchCount = (from a in stats where a.UserId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = (g.Sum(s => s.Assist)) / matchCount,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetInterruptStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where users.Contains(p.User)
                      group p by p.UserId into g
                      let matchCount = (from a in stats where a.UserId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = g.Sum(s => s.Interrupt),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetInterruptPerMatchStat(IList<User> users, IList<BasketballStat> stats)
        {
            return (from a in
                    ((from p in stats
                      where users.Contains(p.User)
                      group p by p.UserId into g
                      let matchCount = (from a in stats where a.UserId == g.Key select a.MatchId).Distinct().Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = (g.Sum(s => s.Interrupt)) / matchCount,
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = Math.Round((decimal)a.Value, 2),
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetWinsStat(IList<User> users, List<MatchResultByUser> matchResultByUsers)
        {
            return (from a in
                     ((from p in matchResultByUsers
                       where users.Contains(p.User) && p.MatchResult != MatchResult.BothOfTeam
                       group p by p.User.Id into g
                       let matchCount = (from a in matchResultByUsers where a.User.Id == g.Key && a.MatchResult != MatchResult.BothOfTeam select a.MatchResult).Count()
                       select new
                       {
                           UserId = g.Key,
                           Value = g.Count(s => s.MatchResult == MatchResult.Win),
                           MatchCount = matchCount
                       }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                         .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = a.Value,
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetWinRatioStat(IList<User> users, List<MatchResultByUser> matchResultByUsers)
        {
            return (from a in
                    ((from p in matchResultByUsers
                      where users.Contains(p.User) && p.MatchResult != MatchResult.BothOfTeam
                      group p by p.User.Id into g
                      let matchCount = (from a in matchResultByUsers where a.User.Id == g.Key && a.MatchResult != MatchResult.BothOfTeam select a.MatchResult).Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = (g.Count(s => s.MatchResult == MatchResult.Win) * 100) / g.Count(),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = a.Value,
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetLoosesStat(IList<User> users, List<MatchResultByUser> matchResultByUsers)
        {
            return (from a in
                    ((from p in matchResultByUsers
                      where users.Contains(p.User) && p.MatchResult != MatchResult.BothOfTeam
                      group p by p.User.Id into g
                      let matchCount = (from a in matchResultByUsers where a.User.Id == g.Key && a.MatchResult != MatchResult.BothOfTeam select a.MatchResult).Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = g.Count(s => s.MatchResult == MatchResult.Loose),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = a.Value,
                        GameCount = a.MatchCount
                    }).ToList();
        }

        public List<StatisticDetail> GetLooseRatioStat(IList<User> users, List<MatchResultByUser> matchResultByUsers)
        {
            return (from a in
                    ((from p in matchResultByUsers
                      where users.Contains(p.User) && p.MatchResult != MatchResult.BothOfTeam
                      group p by p.User.Id into g
                      let matchCount = (from a in matchResultByUsers where a.User.Id == g.Key && a.MatchResult != MatchResult.BothOfTeam select a.MatchResult).Count()
                      select new
                      {
                          UserId = g.Key,
                          Value = (g.Count(s => s.MatchResult == MatchResult.Loose) * 100) / g.Count(),
                          MatchCount = matchCount
                      }).OrderByDescending(r => r.Value).ThenBy(p => p.MatchCount)
                        .Take(Take))
                    join pl in users on a.UserId equals pl.Id
                    select new StatisticDetail
                    {
                        UserId = pl.Id,
                        UserNameSurname = $"{pl.FirstName} {pl.Surname}",
                        Value = a.Value,
                        GameCount = a.MatchCount
                    }).ToList();
        }
    }
}