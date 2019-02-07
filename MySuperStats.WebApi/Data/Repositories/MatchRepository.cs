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

            return await GetAll(predicate: predicate).IncludeMultiple(p => p.HomeTeam, p => p.AwayTeam, p => p.Stats)
                .FirstOrDefaultAsync();
        }

        public async Task<ICustomList<Match>> GetAllAsync()
        {
            return await GetAll().ToCustomList();
        }

        public async Task<ICustomList<MatchForMainScreen>> GetMatchForMainScreen()
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
                              }).OrderBy(p => p.MatchDate).ThenBy(p => p.MatchOrder).ToCustomList();
        }

        public async Task<MatchDetailStats> GetMatchDetailStats(int matchId)
        {
            return await (from p in GetAll()
                          where p.Id == matchId
                          select
                              new MatchDetailStats
                              {
                                  MatchDate = p.MatchDate,
                                  MatchOrder = p.Order,
                                  VideoLink = p.VideoLink,
                                  HomeTeamStats = new TeamStats
                                  {
                                      Team = p.HomeTeam,
                                      PlayerStats =
                                       (
                                            from i in p.Stats
                                            where i.TeamId == p.HomeTeamId
                                            orderby i.Player.Name
                                            select new PlayerStats
                                            {
                                                Player = i.Player,
                                                Stat = i
                                            }
                                       ).ToList()
                                  },
                                  AwayTeamStats = new TeamStats
                                  {
                                      Team = p.AwayTeam,
                                      PlayerStats =
                                       (
                                            from i in p.Stats
                                            where i.TeamId == p.AwayTeamId
                                            orderby i.Player.Name
                                            select new PlayerStats
                                            {
                                                Player = i.Player,
                                                Stat = i
                                            }
                                       ).ToList()
                                  },
                              }).OrderBy(p => p.MatchDate).ThenBy(p => p.MatchOrder).FirstOrDefaultAsync();

        }

    }
}