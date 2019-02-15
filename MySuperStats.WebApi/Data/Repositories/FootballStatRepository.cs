using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.Data.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using MySuperStats.WebApi.Models;
using System.Linq;

namespace MySuperStats.WebApi.Data.Repositories
{
    public class FootballStatRepository : BaseRepository<FootballStat, int>, IFootballStatRepository
    {
        public FootballStatRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<FootballStat> GetByMatchIdTeamIdAndPlayerId(int matchId, int teamId, int playerId)
        {
            var predicate = PredicateBuilder.New<FootballStat>();
            predicate = predicate.And(p => p.MatchId == matchId);
            predicate = predicate.And(p => p.TeamId == teamId);
            predicate = predicate.And(p => p.PlayerId == playerId);

            return await GetAll(predicate: predicate)
                .FirstOrDefaultAsync();
        }

        public async Task<decimal> GetTeamScoreByMatchIdAndTeamId(int matchId, int teamId)
        {
            return await (from p in GetAll()
                          where p.MatchId == matchId
                                && p.TeamId == teamId
                          select p.Goal).FirstOrDefaultAsync();
        }

        public async Task<ICustomList<FootballStat>> GetAllByMatchIdAsync(int matchId)
        {
            return await GetAll(predicate: p => p.MatchId == matchId).ToCustomList();
        }

        public async Task<ICustomList<FootballStat>> GetAllByPlayerIdAsync(int playerId)
        {
            return await GetAll(predicate: p => p.PlayerId == playerId).ToCustomList();
        }

        public async Task<ICustomList<FootballStat>> GetAllAsync()
        {
            return await GetAll().Include(p => p.Match).ToCustomList();
        }

    }
}