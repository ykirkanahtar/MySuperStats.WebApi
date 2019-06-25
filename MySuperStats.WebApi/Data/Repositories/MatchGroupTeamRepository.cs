using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.Data.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.Repositories
{
    public class MatchGroupTeamRepository : BaseRepository<MatchGroupTeam, int> , IMatchGroupTeamRepository
    {
        public MatchGroupTeamRepository(DbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<IList<MatchGroup>> GetMatchGroupsByTeamIdAsync(int teamId)
        {
            var predicate = PredicateBuilder.New<MatchGroupTeam>();
            predicate = predicate.And(p=>p.TeamId == teamId);

            return await GetAll(predicate:predicate).Select(p=>p.MatchGroup).ToListAsync();
        }

        public async Task<IList<Team>> GetTeamsByMatchGroupIdAsync(int matchGroupId)
        {
            var predicate = PredicateBuilder.New<MatchGroupTeam>();
            predicate = predicate.And(p=>p.MatchGroupId == matchGroupId);

            return await GetAll(predicate: predicate).Select(p=>p.Team).ToListAsync();
        }

        public async Task<IList<MatchGroupTeam>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}