using MySuperStats.WebApi.Models;
using CustomFramework.Data.Repositories;
using CustomFramework.Data.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomFramework.Data.Enums;

namespace MySuperStats.WebApi.Data.Repositories
{
    public class MatchRepository : BaseRepository<Match, int>, IMatchRepository
    {

        public MatchRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Match> GetByMatchDateAndOrderAsync(DateTime matchDate, int order)
        {
            var predicate = PredicateBuilder.New<Match>();
            predicate = predicate.And(p => p.MatchDate == matchDate.Date);
            predicate = predicate.And(p => p.Order == order);

            return await GetAll(predicate: predicate).IncludeMultiple(p => p.HomeTeam, p => p.AwayTeam, p => p.BasketballStats, p => p.FootballStats)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<Match>> GetAllByMatchGroupIdAsync(int matchGroupId)
        {
            return await GetAll(predicate: p => p.MatchGroupId == matchGroupId).ToListAsync();
        }

        public async Task<IList<Match>> GetMatchForMainScreen(int matchGroupId)
        {
            //Todo orderby sırası ters çalışıyor. Aşağıdaki kod ilk MatchDate, sonra Order'a göre sıralıyor fakat MatchDate Order'a göre sonra yazılmış. Düzeltilmeli
            return await GetAll(predicate: p => p.MatchGroupId == matchGroupId, orderBy: q => q.OrderBy(s => s.Order).OrderByDescending(s => s.MatchDate))
            .Include(p => p.HomeTeam).Include(p => p.AwayTeam).ToListAsync();
        }

        public async Task<Match> GetMatchDetailBasketballStats(int matchId)
        {
            var match = await (from p in GetAll()
                               where p.Id == matchId
                               select
                                   p
            ).Include(p => p.HomeTeam).Include(p => p.AwayTeam).FirstOrDefaultAsync();

            var homeTeamStats = await (from p in DbContext.Set<BasketballStat>().AsNoTracking()
                                       where p.MatchId == matchId && p.TeamId == match.HomeTeamId && p.Status == Status.Active
                                       select p)
                        .Include(p => p.Player).ThenInclude(p => p.User).ToListAsync();
            var awayTeamStats = await (from p in DbContext.Set<BasketballStat>().AsNoTracking()
                                       where p.MatchId == matchId && p.TeamId == match.AwayTeamId && p.Status == Status.Active
                                       select p)
                        .Include(p => p.Player).ThenInclude(p => p.User).ToListAsync();

            match.HomeTeam.BasketballStats = homeTeamStats;
            match.AwayTeam.BasketballStats = awayTeamStats;

            return match;
        }

        public async Task<Match> GetMatchDetailFootballStats(int matchId)
        {
            var match = await (from p in GetAll()
                               where p.Id == matchId
                               select
                                   p
            ).Include(p => p.HomeTeam).Include(p => p.AwayTeam).FirstOrDefaultAsync();

            var homeTeamStats = await (from p in DbContext.Set<FootballStat>().AsNoTracking()
                                       where p.MatchId == matchId && p.TeamId == match.HomeTeamId && p.Status == Status.Active
                                       select p)
                        .Include(p => p.Player).ThenInclude(p => p.User).ToListAsync();
            var awayTeamStats = await (from p in DbContext.Set<FootballStat>().AsNoTracking()
                                       where p.MatchId == matchId && p.TeamId == match.AwayTeamId && p.Status == Status.Active
                                       select p)
                        .Include(p => p.Player).ThenInclude(p => p.User).ToListAsync();

            match.HomeTeam.FootballStats = homeTeamStats;
            match.AwayTeam.FootballStats = awayTeamStats;

            return match;
        }

    }
}