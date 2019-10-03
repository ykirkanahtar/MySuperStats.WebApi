using System.Linq;
using MySuperStats.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CustomFramework.Data.Enums;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System;
using MySuperStats.WebApi.Utils;
using MySuperStats.Contracts.Responses;
using MySuperStats.Contracts.Enums;

namespace MySuperStats.WebApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _dbContext;
        public UserRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await (from p in _dbContext.Set<User>()
                          where p.Status == Status.Active && p.Id == id
                          select p)
                        .FirstOrDefaultAsync();
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await (from p in _dbContext.Set<User>()
                          where p.Status == Status.Active
                          select p)
                        .ToListAsync();
        }

        public async Task<UserDetailWithBasketballStat> GetByIdWithBasketballStatsAsync(int userId)
        {
            var user = await (from p in _dbContext.Set<User>()
                              where p.Id == userId && p.Status == Status.Active
                              select p)
                        .Include(p => p.BasketballStats)
                            .ThenInclude(p => p.Match)
                        .Include(p => p.BasketballStats)
                            .ThenInclude(p => p.Team)
                        .FirstOrDefaultAsync();

            var basketballStats = user.BasketballStats;

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
                Assist = Math.Round(basketballStats.Where(x => x.Assist != null).Sum(x => x.Assist) ?? 0 / assistMatchCount, 2),
                Interrupt = Math.Round(basketballStats.Where(x => x.Interrupt != null).Sum(x => x.Interrupt) ?? 0 / interruptMatchCount, 2),
                LooseBall = Math.Round(basketballStats.Where(x => x.LooseBall != null).Sum(x => x.LooseBall) ?? 0 / looseBallMatchCount, 2),
                MissingOnePoint = Math.Round(basketballStats.Where(x => x.MissingOnePoint != null).Sum(x => x.MissingOnePoint) ?? 0 / missingOnePointMatchCount, 2),

                MissingTwoPoint = Math.Round(basketballStats.Where(x => x.MissingTwoPoint != null).Sum(x => x.MissingTwoPoint) ?? 0 / twoPointMatchCount, 2),
                OnePoint = Math.Round(basketballStats.Sum(x => x.OnePoint) / matchCount, 2),
                Rebound = Math.Round(basketballStats.Where(x => x.Rebound != null).Sum(x => x.Rebound) ?? 0 / reboundMatchCount, 2),
                StealBall = Math.Round(basketballStats.Where(x => x.StealBall != null).Sum(x => x.StealBall) ?? 0 / stealBallMatchCount, 2),
                TwoPoint = Math.Round(basketballStats.Where(x => x.TwoPoint != null).Sum(x => x.TwoPoint) ?? 0 / twoPointMatchCount, 2)
            };

            var matchForms = basketballStats.GetMatchResultByMatchAndUserId();

            decimal win = matchForms.Count(p => p == MatchResult.Win);
            decimal loose = matchForms.Count(p => p == MatchResult.Loose);
            var winRatio =  matchCount > 0 ? Math.Round(((win * 100) / matchCount), 2) : 0;
            var looseRatio = matchCount > 0 ? Math.Round(((loose * 100) / matchCount), 2) : 0;
            var winLooseTable = new WinLooseTable(win, loose, winRatio, looseRatio);

            var userDetailWithBasketballStat = new UserDetailWithBasketballStat
            {
                User = user,
                Matches = matches,
                TotalStats = totalStats,
                RatioTable = basketballRatioTable,
                PerMatchStats = perMatchStats,
                MatchForms = matchForms,
                WinLooseTable = winLooseTable,
            };
            return userDetailWithBasketballStat;
        }

        public async Task<IList<User>> GetAllByMatchGroupIdAsync(int matchGroupId)
        {
            var users = await (from u in _dbContext.Set<User>()
                               join mu in _dbContext.Set<MatchGroupUser>() on u.Id equals mu.UserId
                               where u.Status == Status.Active && mu.Status == Status.Active
                                     && mu.MatchGroupId == matchGroupId
                               orderby u.FirstName, u.LastName
                               select u)
                        .ToListAsync();

            return users;
        }

        public async Task<IList<Role>> GetRolesByUserIdAsync(int userId)
        {
            return await (from ur in _dbContext.Set<IdentityUserRole<int>>()
                          join r in _dbContext.Set<Role>() on ur.RoleId equals r.Id
                          where ur.UserId == userId
                          && r.Status == Status.Active
                          select r).ToListAsync();
        }
    }
}