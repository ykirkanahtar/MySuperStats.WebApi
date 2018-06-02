using System;
using System.Threading.Tasks;
using BasketballStats.WebApi.Models;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace BasketballStats.WebApi.Data.Repositories
{
    public class MatchRepository : BaseRepository<Match , int>, IMatchRepository
    {
        public MatchRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Match> GetByMatchDateAndOrderAsync(DateTime matchDate, int order)
        {
            var predicate = PredicateBuilder.New<Match>();
            predicate = predicate.And(p => p.MatchDate == matchDate.Date);
            predicate = predicate.And(p => p.Order == order);

            return await GetAll(predicate: predicate).IncludeMultiple(p => p.HomeTeam, p => p.AwayTeam, p => p.Stats)
                .FirstOrDefaultAsync();
        }

        public async Task<ICustomList<Match>> GetAllAsync()
        {
            return await GetAll().IncludeMultiple(p => p.HomeTeam, p => p.AwayTeam, p => p.Stats).ToCustomList();
        }
    }
}