using MySuperStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.Data.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using MySuperStats.Contracts.Responses;

namespace MySuperStats.WebApi.Data.Repositories
{
    public class MatchRepository : BaseRepository<Match, int>, IMatchRepository
    {

        public MatchRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Match> GetByMatchDateAndOrderAsync(DateTime matchDate, int order)
        {
            var predicate = PredicateBuilder.New<Match>();
            predicate = predicate.And(p => p.MatchDate == matchDate.Date);
            predicate = predicate.And(p => p.Order == order);

            return await GetAll(predicate: predicate).IncludeMultiple(p => p.HomeTeam, p => p.AwayTeam, p => p.BasketballStats)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<Match>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<IList<MatchForMainScreen>> GetMatchForMainScreen()
        {
            return await (from p in GetAll()
                          select
                              new MatchForMainScreen
                              {
                                  MatchDate = p.MatchDate,
                                  AwayTeamScore = (int)p.AwayTeamScore,
                                  HomeTeamScore = (int)p.HomeTeamScore,
                                  AwayTeamName = p.AwayTeam.Name,
                                  HomeTeamName = p.HomeTeam.Name,
                                  MatchDuration = p.DurationInMinutes,
                                  MatchId = p.Id,
                                  MatchOrder = p.Order,
                                  VideoLink = p.VideoLink
                              }).OrderBy(p => p.MatchDate).ThenBy(p => p.MatchOrder).ToListAsync();
        }

        public async Task<MatchDetailBasketballStats> GetMatchDetailBasketballStats(int matchId)
        {
            return await (from p in GetAll()
                          where p.Id == matchId
                          select
                              new MatchDetailBasketballStats
                              {
                                  MatchDate = p.MatchDate,
                                  MatchOrder = p.Order,
                                  VideoLink = p.VideoLink,
                                  HomeTeamBasketballStats = new TeamBasketballStats
                                  {
                                      Team = p.HomeTeam,
                                      PlayerBasketballStats =
                                       (
                                            from i in p.BasketballStats
                                            where i.TeamId == p.HomeTeamId
                                            orderby i.User.FirstName
                                            select new PlayerBasketballStats
                                            {
                                                Player = i.User,
                                                BasketballStat = i
                                            }
                                       ).ToList()
                                  },
                                  AwayTeamBasketballStats = new TeamBasketballStats
                                  {
                                      Team = p.AwayTeam,
                                      PlayerBasketballStats =
                                       (
                                            from i in p.BasketballStats
                                            where i.TeamId == p.AwayTeamId
                                            orderby i.User.FirstName
                                            select new PlayerBasketballStats
                                            {
                                                Player = i.User,
                                                BasketballStat = i
                                            }
                                       ).ToList()
                                  },
                              }).OrderBy(p => p.MatchDate).ThenBy(p => p.MatchOrder).FirstOrDefaultAsync();

        }

    }
}