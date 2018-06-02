using System.Threading.Tasks;
using BasketballStats.WebApi.Models;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Utils;
using Microsoft.EntityFrameworkCore;

namespace BasketballStats.WebApi.Data.Repositories
{
    public class PlayerRepository : BaseRepository<Player, int>, IPlayerRepository
    {
        public PlayerRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICustomList<Player>> GetAllAsync()
        {
            return await GetAll().IncludeMultiple(p => p.Stats).ToCustomList();
        }
    }
}