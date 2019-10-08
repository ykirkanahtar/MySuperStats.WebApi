using System.Threading.Tasks;
using CustomFramework.Data.Repositories;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using MySuperStats.WebApi.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore.Query;

namespace MySuperStats.WebApi.Data.Repositories
{
    public class FootballStatRepository : BaseRepository<FootballStat, int>, IFootballStatRepository
    {
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

        public async Task<IList<FootballStat>> GetAllByPlayerIdAsync(int playerId)
        {
            return await GetAll(predicate: p => p.PlayerId == playerId).ToListAsync();
        }

        public async Task<IList<FootballStat>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }

    }
}