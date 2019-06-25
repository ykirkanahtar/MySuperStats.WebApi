using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.Data.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.Repositories
{
    public class MatchGroupRepository : BaseRepository<MatchGroup, int>, IMatchGroupRepository
    {
        public MatchGroupRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IList<MatchGroup>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<MatchGroup> GetByGroupNameAsync(string groupName)
        {
            return await GetAll(predicate: p => EF.Functions.Like(p.GroupName.ToLower(), $"{groupName.ToLower()}%")).FirstOrDefaultAsync();
        }
    }
}