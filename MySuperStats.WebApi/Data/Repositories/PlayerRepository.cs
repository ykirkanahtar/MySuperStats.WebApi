using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data.Enums;
using CustomFramework.Data.Repositories;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Models;
using MySuperStats.Contracts.Utils;

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

        public async Task<UserDetailWithBasketballStat> GetByIdWithBasketballStatsAsync(int playerId)
        {
            var player = await (from p in DbContext.Set<Player>()
                                where p.Id == playerId && p.Status == Status.Active
                                select p)
                        .Include(p => p.BasketballStats)
                            .ThenInclude(p => p.Match)
                        .Include(p => p.User)
                        .Include(p => p.BasketballStats)
                            .ThenInclude(p => p.Team)
                        .FirstOrDefaultAsync();

            var basketballStats = player.BasketballStats;

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
            };

            var onePointRatio = totalStats.OnePoint + (totalStats.MissingOnePoint ?? 0) > 0 ? Math.Round(totalStats.OnePoint / (totalStats.OnePoint + totalStats.MissingOnePoint ?? 0) * 100, 2) : 0;
            var twoPointRatio = (totalStats.TwoPoint ?? 0) + (totalStats.MissingTwoPoint ?? 0) > 0 ? Math.Round((totalStats.TwoPoint ?? 0) / ((totalStats.TwoPoint ?? 0) + (totalStats.MissingTwoPoint) ?? 0) * 100, 2) : 0;
            var basketballRatioTable = new BasketballRatioTable(onePointRatio, twoPointRatio);

            var perMatchStats = new BasketballStat
            {
                Assist = assistMatchCount > 0 ? Math.Round(basketballStats.Where(x => x.Assist != null).Sum(x => x.Assist) ?? 0 / assistMatchCount, 2) : 0,
                Interrupt = interruptMatchCount > 0 ? Math.Round(basketballStats.Where(x => x.Interrupt != null).Sum(x => x.Interrupt) ?? 0 / interruptMatchCount, 2) : 0,
                LooseBall = looseBallMatchCount > 0 ? Math.Round(basketballStats.Where(x => x.LooseBall != null).Sum(x => x.LooseBall) ?? 0 / looseBallMatchCount, 2) : 0,
                MissingOnePoint = missingOnePointMatchCount > 0 ? Math.Round(basketballStats.Where(x => x.MissingOnePoint != null).Sum(x => x.MissingOnePoint) ?? 0 / missingOnePointMatchCount, 2) : 0,

                MissingTwoPoint = twoPointMatchCount > 0 ? Math.Round(basketballStats.Where(x => x.MissingTwoPoint != null).Sum(x => x.MissingTwoPoint) ?? 0 / twoPointMatchCount, 2) : 0,
                OnePoint = matchCount > 0 ? Math.Round(basketballStats.Sum(x => x.OnePoint) / matchCount, 2) : 0,
                Rebound = reboundMatchCount > 0 ? Math.Round(basketballStats.Where(x => x.Rebound != null).Sum(x => x.Rebound) ?? 0 / reboundMatchCount, 2) : 0,
                StealBall = stealBallMatchCount > 0 ? Math.Round(basketballStats.Where(x => x.StealBall != null).Sum(x => x.StealBall) ?? 0 / stealBallMatchCount, 2) : 0,
                TwoPoint = twoPointMatchCount > 0 ? Math.Round(basketballStats.Where(x => x.TwoPoint != null).Sum(x => x.TwoPoint) ?? 0 / twoPointMatchCount, 2) : 0
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