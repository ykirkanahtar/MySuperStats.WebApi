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

        public async Task<ICustomList<MatchGroup>> GetAllAsync()
        {
            return await GetAll().ToCustomList();
        }

        public async Task<MatchGroup> GetByGroupNameAsync(string groupName)
        {
            var predicate = PredicateBuilder.New<MatchGroup>();
            predicate = predicate.And(p=>p.GroupName == groupName);

            return await GetAll(predicate: predicate).FirstOrDefaultAsync();
        }
    }
}