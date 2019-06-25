using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.Data.Utils;
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

        public async Task<IList<User>> GetUsersByMatchGroupIdAsync(int matchGroupId)
        {
            var predicate = PredicateBuilder.New<MatchGroupUser>();
            predicate = predicate.And(p => p.MatchGroupId == matchGroupId);

            return await GetAll(predicate: predicate).Select(p => p.User).ToListAsync();
        }

        public async Task<IList<MatchGroupUser>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}