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
        private readonly ApplicationContext _dbContext;
        public UserRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await (from p in _dbContext.Set<User>()
                          where p.Status == Status.Active && p.Id == id
                          select p)
                        .FirstOrDefaultAsync();
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await (from p in _dbContext.Set<User>()
                          where p.Status == Status.Active
                          select p)
                        .ToListAsync();
        }

        public async Task<User> GetByIdWithBasketballStatsAsync(int userId)
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

        public async Task<IList<User>> GetAllByMatchGroupIdAsync(int matchGroupId)
        {
            var users = await (from u in _dbContext.Set<User>()
                               join mu in _dbContext.Set<MatchGroupUser>() on u.Id equals mu.UserId
                               where u.Status == Status.Active && mu.Status == Status.Active
                                     && mu.MatchGroupId == matchGroupId
                               select u)
                        .ToListAsync();

            return users;
        }

        // public async Task<IList<Role>> GetRolesAsync(int userId, int matchGroupId)
        // {
        //     return await (from ur in _dbContext.Set<UserRole>()
        //                   join r in _dbContext.Set<Role>() on ur.RoleId equals r.Id
        //                   where ur.UserId == userId && ur.MatchGroupId == matchGroupId
        //                   && r.Status == Status.Active
        //                   select r).ToListAsync();
        // }

        // public void AddUserToRole(UserRole request)
        // {
        //     var result = _dbContext.Set<UserRole>().Add(request);
        // }

        // public void RemoveUserFromRole(UserRole request)
        // {
        //     _dbContext.Set<UserRole>().Remove(request);
        // }

        // public async Task<IList<UserRole>> GetUserRolesByMatchGroupIdAsync(int matchGroupId)
        // {
        //     return await (from ur in _dbContext.Set<UserRole>()
        //                   where ur.MatchGroupId == matchGroupId
        //                   select ur).Include(p => p.User).Include(p => p.Role).ToListAsync();
        // }
    }
}