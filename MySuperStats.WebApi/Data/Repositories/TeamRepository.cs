using MySuperStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.Data.Utils;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MySuperStats.WebApi.Data.Repositories
{
    public class TeamRepository : BaseRepository<Team, int>, ITeamRepository
    {
        public TeamRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Team> GetByNameAsync(string name)
        {
            return await GetAll().IncludeMultiple(p => p.HomeMatches, p => p.AwayMatches, p => p.BasketballStats).FirstOrDefaultAsync();
        }

        public async Task<ICustomList<Team>> GetAllAsync()
        {
            return await GetAll().ToCustomList();
        }
    }
}