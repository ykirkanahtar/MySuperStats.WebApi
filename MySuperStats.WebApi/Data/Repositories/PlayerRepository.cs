using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data.Repositories;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Models;
using MySuperStats.Contracts.Utils;
using CustomFramework.Data.Contracts;

namespace MySuperStats.WebApi.Data.Repositories
{
    public class PlayerRepository : BaseRepository<Player, int>, IPlayerRepository
    {
        private readonly IMapper _mapper;

        private static readonly Func<IQueryable<Player>, IIncludableQueryable<Player, object>> includes = source => source.Include(p => p.User);

        public PlayerRepository(DbContext dbContext, IMapper mapper) : base(dbContext, includes)
        {
            _mapper = mapper;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var predicate = PredicateBuilder.New<Player>();
            predicate = predicate.And(p => p.Id == id);

            return await GetAll(predicate: predicate).Select(p => p.User).FirstOrDefaultAsync();
        }

        public async Task<UserDetailWithBasketballStat> GetByIdWithBasketballStatsAsync(int playerId, int matchGroupId)
        {
            var player = await (from p in DbContext.Set<Player>()
                                join mu in DbContext.Set<MatchGroupUser>() on p.Id equals mu.PlayerId
                                join mg in DbContext.Set<MatchGroup>() on mu.MatchGroupId equals mg.Id
                                where p.Id == playerId && p.Status == Status.Active && mu.Status == Status.Active
                                     && mg.Status == Status.Active
                                select p)
                                .Include(p => p.User)
                        .FirstOrDefaultAsync();

            var basketballStats = await (from m in DbContext.Set<Match>()
                                         join bs in DbContext.Set<BasketballStat>() on m.Id equals bs.MatchId
                                         join mg in DbContext.Set<MatchGroup>() on m.MatchGroupId equals mg.Id
                                         join p in DbContext.Set<Player>() on bs.PlayerId equals p.Id
                                         join mu in DbContext.Set<MatchGroupUser>() on mg.Id equals mu.MatchGroupId
                                         where m.MatchGroupId == matchGroupId
                                            && bs.PlayerId == playerId
                                            && mu.PlayerId == p.Id
                                            && m.Status == Status.Active
                                            && bs.Status == Status.Active
                                            && mg.Status == Status.Active
                                            && p.Status == Status.Active
                                         select bs
                                        )
                                        .Include(p => p.Match)
                                        .Include(p => p.Team)
                                        .ToListAsync();

            var matches = (from p in basketballStats select p.Match).ToList();
            var matchCount = ((from p in matches select p.Id).Distinct()).Count();

            var missingOnePointMatchCount = (from p in basketballStats where p.MissingOnePoint != null select p.MatchId).Distinct().Count();
            var twoPointMatchCount = (from p in basketballStats where p.TwoPoint != null select p.MatchId).Distinct().Count();
            var missingTwoPointMatchCount = (from p in basketballStats where p.MissingTwoPoint != null select p.MatchId).Distinct().Count();
            var assistMatchCount = (from p in basketballStats where p.Assist != null select p.MatchId).Distinct().Count();
            var interruptMatchCount = (from p in basketballStats where p.Interrupt != null select p.MatchId).Distinct().Count();
            var looseBallMatchCount = (from p in basketballStats where p.LooseBall != null select p.MatchId).Distinct().Count();
            var reboundMatchCount = (from p in basketballStats where p.Rebound != null select p.MatchId).Distinct().Count();
            var stealBallMatchCount = (from p in basketballStats where p.StealBall != null select p.MatchId).Distinct().Count();
            var laneMatchCount = (from p in basketballStats where (p.Lane != null || p.LaneWithoutPoint != null) select p.MatchId).Distinct().Count();

            var totalStats = new BasketballStat
            {
                Assist = basketballStats.Where(x => x.Assist != null).Sum(x => x.Assist),
                Interrupt = basketballStats.Where(x => x.Interrupt != null).Sum(x => x.Interrupt),
                LooseBall = basketballStats.Where(x => x.LooseBall != null).Sum(x => x.LooseBall),
                MissingOnePoint = basketballStats.Where(x => x.MissingOnePoint != null).Sum(x => x.MissingOnePoint),
                MissingTwoPoint = basketballStats.Where(x => x.MissingTwoPoint != null).Sum(x => x.MissingTwoPoint),
                OnePoint = basketballStats.Sum(x => x.OnePoint),
                Rebound = basketballStats.Where(x => x.Rebound != null).Sum(x => x.Rebound),
                StealBall = basketballStats.Where(x => x.StealBall != null).Sum(x => x.StealBall),
                TwoPoint = basketballStats.Where(x => x.TwoPoint != null).Sum(x => x.TwoPoint),
                Lane = (basketballStats.Where(x => x.Lane != null).Sum(x => x.Lane)
                        +
                        (basketballStats.Where(x => x.LaneWithoutPoint != null).Sum(x => x.LaneWithoutPoint)))
            };

            var onePointRatio = totalStats.OnePoint + (totalStats.MissingOnePoint ?? 0) > 0 ? Math.Round(totalStats.OnePoint / (totalStats.OnePoint + totalStats.MissingOnePoint ?? 0) * 100, 2) : 0;
            var twoPointRatio = (totalStats.TwoPoint ?? 0) + (totalStats.MissingTwoPoint ?? 0) > 0 ? Math.Round((totalStats.TwoPoint ?? 0) / ((totalStats.TwoPoint ?? 0) + (totalStats.MissingTwoPoint) ?? 0) * 100, 2) : 0;
            var basketballRatioTable = new BasketballRatioTable(onePointRatio, twoPointRatio);

            var perMatchStats = new BasketballStat
            {
                Assist = assistMatchCount > 0 ? Math.Round(totalStats.Assist ?? 0 / assistMatchCount, 2) : 0,
                Interrupt = interruptMatchCount > 0 ? Math.Round(totalStats.Interrupt ?? 0 / interruptMatchCount, 2) : 0,
                LooseBall = looseBallMatchCount > 0 ? Math.Round(totalStats.LooseBall ?? 0 / looseBallMatchCount, 2) : 0,
                MissingOnePoint = missingOnePointMatchCount > 0 ? Math.Round(totalStats.MissingOnePoint ?? 0 / missingOnePointMatchCount, 2) : 0,
                MissingTwoPoint = twoPointMatchCount > 0 ? Math.Round(totalStats.MissingTwoPoint ?? 0 / twoPointMatchCount, 2) : 0,
                OnePoint = matchCount > 0 ? Math.Round(totalStats.OnePoint / matchCount, 2) : 0,
                Rebound = reboundMatchCount > 0 ? Math.Round(totalStats.Rebound ?? 0 / reboundMatchCount, 2) : 0,
                StealBall = stealBallMatchCount > 0 ? Math.Round(totalStats.StealBall ?? 0 / stealBallMatchCount, 2) : 0,
                TwoPoint = twoPointMatchCount > 0 ? Math.Round(totalStats.TwoPoint ?? 0 / twoPointMatchCount, 2) : 0,
                Lane = laneMatchCount > 0 ? Math.Round(totalStats.Lane ?? 0 / laneMatchCount, 2) : 0
            };

            var basketballStatsResponse = _mapper.Map<ICollection<BasketballStatResponse>>(basketballStats);
            var matchForms = basketballStatsResponse.GetMatchResultByMatchAndPlayerId();

            decimal win = matchForms.Count(p => p == MatchResult.Win);
            decimal loose = matchForms.Count(p => p == MatchResult.Loose);
            var winRatio = matchCount > 0 ? Math.Round(((win * 100) / matchCount), 2) : 0;
            var looseRatio = matchCount > 0 ? Math.Round(((loose * 100) / matchCount), 2) : 0;
            var winLooseTable = new WinLooseTable(win, loose, winRatio, looseRatio);

            var userDetailWithBasketballStat = new UserDetailWithBasketballStat
            {
                Player = player,
                Matches = matches,
                TotalStats = totalStats,
                RatioTable = basketballRatioTable,
                PerMatchStats = perMatchStats,
                MatchForms = matchForms,
                WinLooseTable = winLooseTable,
            };
            return userDetailWithBasketballStat;
        }

        public async Task<UserDetailWithFootballStat> GetByIdWithFootballStatsAsync(int playerId, int matchGroupId)
        {
            var player = await (from p in DbContext.Set<Player>()
                                join mu in DbContext.Set<MatchGroupUser>() on p.Id equals mu.PlayerId
                                join mg in DbContext.Set<MatchGroup>() on mu.MatchGroupId equals mg.Id
                                where p.Id == playerId && p.Status == Status.Active && mu.Status == Status.Active
                                     && mg.Status == Status.Active
                                select p)
                                .Include(p => p.User)
                        .FirstOrDefaultAsync();

            var footballStats = await (from m in DbContext.Set<Match>()
                                       join fs in DbContext.Set<FootballStat>() on m.Id equals fs.MatchId
                                       join mg in DbContext.Set<MatchGroup>() on m.MatchGroupId equals mg.Id
                                       join p in DbContext.Set<Player>() on fs.PlayerId equals p.Id
                                       join mu in DbContext.Set<MatchGroupUser>() on mg.Id equals mu.MatchGroupId
                                       where m.MatchGroupId == matchGroupId
                                          && fs.PlayerId == playerId
                                          && mu.PlayerId == p.Id
                                          && m.Status == Status.Active
                                          && fs.Status == Status.Active
                                          && mg.Status == Status.Active
                                          && p.Status == Status.Active
                                       select fs
                                        )
                                        .Include(p => p.Match)
                                        .Include(p => p.Team)
                                        .ToListAsync();

            var matches = (from p in footballStats select p.Match).ToList();
            var matchCount = ((from p in matches select p.Id).Distinct()).Count();

            var ownGoalMatchCount = (from p in footballStats where p.OwnGoal != null select p.MatchId).Distinct().Count();
            var penaltyScoreMatchCount = (from p in footballStats where p.PenaltyScore != null select p.MatchId).Distinct().Count();
            var missedPenaltyMatchCount = (from p in footballStats where p.MissedPenalty != null select p.MatchId).Distinct().Count();
            var assistMatchCount = (from p in footballStats where p.Assist != null select p.MatchId).Distinct().Count();
            var saveGoalMatchCount = (from p in footballStats where p.SaveGoal != null select p.MatchId).Distinct().Count();
            var concedeGoalMatchCount = (from p in footballStats where p.ConcedeGoal != null select p.MatchId).Distinct().Count();

            var totalStats = new FootballStat
            {
                Assist = footballStats.Where(x => x.Assist != null).Sum(x => x.Assist),
                SaveGoal = footballStats.Where(x => x.SaveGoal != null).Sum(x => x.SaveGoal),
                OwnGoal = footballStats.Where(x => x.OwnGoal != null).Sum(x => x.OwnGoal),
                PenaltyScore = footballStats.Where(x => x.PenaltyScore != null).Sum(x => x.PenaltyScore),
                MissedPenalty = footballStats.Where(x => x.MissedPenalty != null).Sum(x => x.MissedPenalty),
                Goal = footballStats.Sum(x => x.Goal),
                ConcedeGoal = footballStats.Where(x => x.ConcedeGoal != null).Sum(x => x.ConcedeGoal),
            };

            var perMatchStats = new FootballStat
            {
                Assist = assistMatchCount > 0 ? Math.Round(footballStats.Where(x => x.Assist != null).Sum(x => x.Assist) ?? 0 / assistMatchCount, 2) : 0,
                SaveGoal = saveGoalMatchCount > 0 ? Math.Round(footballStats.Where(x => x.SaveGoal != null).Sum(x => x.SaveGoal) ?? 0 / saveGoalMatchCount, 2) : 0,
                OwnGoal = ownGoalMatchCount > 0 ? Math.Round(footballStats.Where(x => x.OwnGoal != null).Sum(x => x.OwnGoal) ?? 0 / ownGoalMatchCount, 2) : 0,
                PenaltyScore = penaltyScoreMatchCount > 0 ? Math.Round(footballStats.Where(x => x.PenaltyScore != null).Sum(x => x.PenaltyScore) ?? 0 / penaltyScoreMatchCount, 2) : 0,

                MissedPenalty = missedPenaltyMatchCount > 0 ? Math.Round(footballStats.Where(x => x.MissedPenalty != null).Sum(x => x.MissedPenalty) ?? 0 / missedPenaltyMatchCount, 2) : 0,
                Goal = matchCount > 0 ? Math.Round(footballStats.Sum(x => x.Goal) / matchCount, 2) : 0,
                ConcedeGoal = concedeGoalMatchCount > 0 ? Math.Round(footballStats.Where(x => x.ConcedeGoal != null).Sum(x => x.ConcedeGoal) ?? 0 / concedeGoalMatchCount, 2) : 0,
            };

            var footballStatsResponse = _mapper.Map<ICollection<FootballStatResponse>>(footballStats);
            var matchForms = footballStatsResponse.GetMatchResultByMatchAndPlayerId();

            decimal win = matchForms.Count(p => p == MatchResult.Win);
            decimal loose = matchForms.Count(p => p == MatchResult.Loose);
            var winRatio = matchCount > 0 ? Math.Round(((win * 100) / matchCount), 2) : 0;
            var looseRatio = matchCount > 0 ? Math.Round(((loose * 100) / matchCount), 2) : 0;
            var winLooseTable = new WinLooseTable(win, loose, winRatio, looseRatio);

            var userDetailWithBasketballStat = new UserDetailWithFootballStat
            {
                Player = player,
                Matches = matches,
                TotalStats = totalStats,
                PerMatchStats = perMatchStats,
                MatchForms = matchForms,
                WinLooseTable = winLooseTable,
            };
            return userDetailWithBasketballStat;
        }


        public async Task<IList<Player>> GetAllByMatchGroupIdAsync(int matchGroupId)
        {
            return await (from p in DbContext.Set<MatchGroupUser>()
                          where p.Status == Status.Active
                                && p.Player.Status == Status.Active
                                && p.MatchGroup.Status == Status.Active
                                && p.MatchGroupId == matchGroupId
                          orderby p.Player.FirstName, p.Player.LastName
                          select p.Player)
                        .ToListAsync();
        }
    }
}