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
    public class MatchGroupPlayerRepository : BaseRepository<MatchGroupPlayer, int>, IMatchGroupPlayerRepository
    {
        public MatchGroupPlayerRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<ICustomList<MatchGroup>> GetMatchGroupsByPlayerIdAsync(int playerId)
        {
            var predicate = PredicateBuilder.New<MatchGroupPlayer>();
            predicate = predicate.And(p => p.PlayerId == playerId);

            return (await GetAll(predicate: predicate).Select(p => p.MatchGroup).ToListAsync()).ToCustomList();
        }

        public async Task<ICustomList<Player>> GetPlayersByMatchGroupIdAsync(int matchGroupId)
        {
            var predicate = PredicateBuilder.New<MatchGroupPlayer>();
            predicate = predicate.And(p => p.MatchGroupId == matchGroupId);

            return (await GetAll(predicate: predicate).Select(p => p.Player).ToListAsync()).ToCustomList();
        }

        public async Task<ICustomList<MatchGroupPlayer>> GetAllAsync()
        {
            return await GetAll().ToCustomList();
        }
    }
}