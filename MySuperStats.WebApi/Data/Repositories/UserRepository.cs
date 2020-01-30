using System.Linq;
using MySuperStats.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using CustomFramework.BaseWebApi.Contracts;

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
                        .Include(p=>p.Player)
                        .FirstOrDefaultAsync();
        }

        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            return await (from p in _dbContext.Set<User>()
                          where p.Status == Status.Active && p.Id == id
                          select p.Player)
                        .FirstOrDefaultAsync();
        }        

        public async Task<Player> GetPlayerByEmailAsync(string email)
        {
            return await (from p in _dbContext.Set<User>()
                          where p.Status == Status.Active && p.Email == email
                          select p.Player)
                        .FirstOrDefaultAsync();
        }         

        public async Task<IList<User>> GetAllAsync()
        {
            return await (from p in _dbContext.Set<User>()
                          where p.Status == Status.Active
                          select p)
                        .Include(p=>p.Player)
                        .ToListAsync();
        }

        public async Task<IList<User>> GetAllByMatchGroupIdAsync(int matchGroupId)
        {
            var users = await (from u in _dbContext.Set<User>()
                               join mu in _dbContext.Set<MatchGroupUser>() on u.Id equals mu.UserId
                               join p in _dbContext.Set<Player>() on u.Id equals p.UserId
                               where u.Status == Status.Active && mu.Status == Status.Active 
                                    && p.Status == Status.Active
                                     && mu.MatchGroupId == matchGroupId
                               orderby p.FirstName, p.LastName
                               select u)
                        .Include(p => p.Player)
                        .ToListAsync();

            return users;
        }

        public async Task<IList<Role>> GetRolesByUserIdAsync(int userId)
        {
            return await (from ur in _dbContext.Set<IdentityUserRole<int>>()
                          join r in _dbContext.Set<Role>() on ur.RoleId equals r.Id
                          where ur.UserId == userId
                          && r.Status == Status.Active
                          select r)
                          .ToListAsync();
        }
    }
}