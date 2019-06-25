using System.Linq;
using MySuperStats.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CustomFramework.Data.Enums;
using System.Collections.Generic;

namespace MySuperStats.WebApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _dbContext;
        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await (from p in _dbContext.Set<User>()
                          where p.Status == Status.Active
                          select p)
                        .ToListAsync();
        }

        public async Task<User> GetByIdWithBasketballStats(int userId)
        {
            var user = await (from p in _dbContext.Set<User>()
                              where p.Id == userId && p.Status == Status.Active
                              select p)
                        .Include(p => p.BasketballStats)
                            .ThenInclude(p => p.Match)
                        .Include(p => p.BasketballStats)
                            .ThenInclude(p => p.Team)
                        .FirstOrDefaultAsync();

            return user;
        }
    }
}