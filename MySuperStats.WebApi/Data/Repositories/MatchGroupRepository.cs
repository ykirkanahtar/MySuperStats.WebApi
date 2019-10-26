using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using MySuperStats.WebApi.Models;
using System.Linq;
using CustomFramework.Data.Contracts;

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

        public async Task<MatchGroup> GetByMatchIdAsync(int matchId)
        {
            return await (from m in DbContext.Set<Match>()
                          where m.Id == matchId && m.Status == Status.Active
                               && m.Status == Status.Active
                          select m.MatchGroup)
                        .FirstOrDefaultAsync();
        }

        public async Task<MatchGroup> GetByGroupNameAsync(string groupName)
        {
            return await GetAll(predicate: p => EF.Functions.Like(p.GroupName.ToLower(), $"{groupName.ToLower()}%")).FirstOrDefaultAsync();
        }
    }
}