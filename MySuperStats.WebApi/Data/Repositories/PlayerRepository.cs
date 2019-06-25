using System.Linq;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.Data.Utils;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using Microsoft.EntityFrameworkCore.Query;

namespace MySuperStats.WebApi.Data.Repositories
{
    public class PlayerRepository : BaseRepository<Player, int>, IPlayerRepository
    {
        private static readonly Func<IQueryable<Player>, IIncludableQueryable<Player, object>> includes = source => source.Include(p => p.BasketballStats).ThenInclude(p => p.Match).Include(p => p.BasketballStats).ThenInclude(p => p.Team);

        public PlayerRepository(DbContext dbContext) : base(dbContext, includes)
        {

        }

        public async Task<Player> GetByIdWithIncludeAsync(int playerId)
        {
            return await (from p in GetAll()
                          where p.Id == playerId
                          select p).FirstOrDefaultAsync();
        }

        public async Task<IList<Player>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}