using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomFramework.Data.Repositories;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.Repositories
{
    public class MatchGroupUserRepository : BaseRepository<MatchGroupUser, int>, IMatchGroupUserRepository
    {
        public MatchGroupUserRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IList<MatchGroup>> GetMatchGroupsByUserIdAsync(int userId)
        {
            var predicate = PredicateBuilder.New<MatchGroupUser>();
            predicate = predicate.And(p => p.UserId == userId);

            return await GetAll(predicate: predicate).Select(p => p.MatchGroup).ToListAsync();
        }

        public async Task<IList<MatchGroupUser>> GetAllByMatchGroupIdAsync(int matchGroupId)
        {
            var predicate = PredicateBuilder.New<MatchGroupUser>();
            predicate = predicate.And(p => p.MatchGroupId == matchGroupId);

            return await GetAll(predicate: predicate).Include(p => p.User).Include(p => p.Role).ToListAsync();
        }

        public async Task<IList<User>> GetUsersByMatchGroupIdAsync(int matchGroupId)
        {
            var predicate = PredicateBuilder.New<MatchGroupUser>();
            predicate = predicate.And(p => p.MatchGroupId == matchGroupId);

            return await GetAll(predicate: predicate).Select(p => p.User).ToListAsync();
        }

        public async Task<MatchGroupUser> GetByMatchGroupIdAndUserIdAsync(int matchGroupId, int userId)
        {
            var predicate = PredicateBuilder.New<MatchGroupUser>();
            predicate = predicate.And(p => p.MatchGroupId == matchGroupId);
            predicate = predicate.And(p => p.UserId == userId);

            return await GetAll(predicate: predicate).Include(p => p.Role).FirstOrDefaultAsync();
        }

        public async Task<bool> UserIsInMatchGroupAsync(int matchGroupId, int userId)
        {
            var result = await GetAll(predicate: p => p.UserId == userId && p.MatchGroupId == matchGroupId).Select(p => p.MatchGroup).ToListAsync();
            return result.Count > 0;
        }

        public async Task<IList<MatchGroupUser>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}