using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.Data.Utils;
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

        public async Task<FootballStat> GetByMatchIdTeamIdAndUserId(int matchId, int teamId, int userId)
        {
            var predicate = PredicateBuilder.New<FootballStat>();
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
                          select p.Goal).FirstOrDefaultAsync();
        }

        public async Task<IList<FootballStat>> GetAllByMatchIdAsync(int matchId)
        {
            return await GetAll(predicate: p => p.MatchId == matchId).ToListAsync();
        }

        public async Task<IList<FootballStat>> GetAllByUserIdAsync(int userId)
        {
            return await GetAll(predicate: p => p.UserId == userId).ToListAsync();
        }

        public async Task<IList<FootballStat>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }

    }
}