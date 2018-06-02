using System.Threading.Tasks;
using BasketballStats.WebApi.Models;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace BasketballStats.WebApi.Data.Repositories
{
    public class StatRepository : BaseRepository<Stat, int>, IStatRepository
    {
        public StatRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Stat> GetByMatchIdTeamIdAndPlayerId(int matchId, int teamId, int playerId)
        {
            var predicate = PredicateBuilder.New<Stat>();
            predicate = predicate.And(p => p.MatchId == matchId);
            predicate = predicate.And(p => p.TeamId == teamId);
            predicate = predicate.And(p => p.PlayerId == playerId);

            return await GetAll(predicate: predicate).IncludeMultiple(p => p.Match, p => p.Team, p => p.Player)
                .FirstOrDefaultAsync();
        }

        public async Task<ICustomList<Stat>> GetAllByMatchIdAsync(int matchId)
        {
            return await GetAll(predicate: p => p.MatchId == matchId).IncludeMultiple(p => p.Match, p => p.Player, p => p.Team).ToCustomList();
        }

        public async Task<ICustomList<Stat>> GetAllByPlayerIdAsync(int playerId)
        {
            return await GetAll(predicate: p => p.PlayerId == playerId).IncludeMultiple(p => p.Match, p => p.Player, p => p.Team).ToCustomList();
        }

        public async Task<ICustomList<Stat>> GetAllAsync()
        {
            return await GetAll().IncludeMultiple(p => p.Match, p => p.Player, p => p.Team).ToCustomList();
        }
    }
}