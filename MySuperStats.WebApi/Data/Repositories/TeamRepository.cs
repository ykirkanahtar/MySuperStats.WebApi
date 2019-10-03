using MySuperStats.WebApi.Models;
using CustomFramework.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;

namespace MySuperStats.WebApi.Data.Repositories
{
    public class TeamRepository : BaseRepository<Team, int>, ITeamRepository
    {
        private static readonly Func<IQueryable<Team>, IIncludableQueryable<Team, object>> includes = source => source.Include(p => p.HomeMatches).Include(p => p.AwayMatches).Include(p => p.BasketballStats);
        public TeamRepository(DbContext dbContext) : base(dbContext, includes)
        {

        }

        public async Task<Team> GetByNameAsync(string name)
        {
            return await GetAll(predicate: p => EF.Functions.Like(p.TeamName.ToLower(), $"{name.ToLower()}%")).FirstOrDefaultAsync();
        }

        public async Task<IList<Team>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}