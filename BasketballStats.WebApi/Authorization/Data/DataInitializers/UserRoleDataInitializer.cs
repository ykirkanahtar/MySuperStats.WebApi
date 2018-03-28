using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Data.Contracts;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Authorization.Data.DataInitializers
{
    public class UserRoleDataInitializer : BaseDataInitializer
    {
        public UserRoleDataInitializer(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task Seed()
        {
            var users = ConfigHelper.GetSection("Users");
            foreach (var section in users.GetChildren())
            {
                var userName = section.GetValue<string>("UserName");
                var userRoles = section.GetSection("Roles").Get<string[]>();

                var user = GetUsersByUserNameAsync(userName).Result[0];

                foreach (var roleName in userRoles)
                {

                    var role = GetRolesByNameAsync(roleName).Result[0];

                    if (GetUserRolesByUserIdAndRoleIdAsync(role.Id, user.Id).Result.Count > 0) continue;

                    var userRole = new UserRole()
                    {
                        UserId = user.Id,
                        RoleId = role.Id,
                    };

                    UnitOfWork.GetRepository<UserRole, int>().Add(userRole);
                }

                await UnitOfWork.SaveChangesAsync();
            }
        }

        private async Task<IList<UserRole>> GetUserRolesByUserIdAndRoleIdAsync(int roleId, int userId)
        {
            var predicate = PredicateBuilder.New<UserRole>();
            predicate = predicate.And(p => p.RoleId == roleId);
            predicate = predicate.And(p => p.UserId == userId);

            return await UnitOfWork.GetRepository<UserRole, int>()
                .GetAll(0, ApiConstants.DefaultListCount, predicate, out var _).Select(p => p).ToListAsync();
        }

        private async Task<IList<Role>> GetRolesByNameAsync(string name)
        {
            var predicate = PredicateBuilder.New<Role>();
            predicate = predicate.And(p => p.RoleName == name);

            return await UnitOfWork.GetRepository<Role, int>()
                .GetAll(0, ApiConstants.DefaultListCount, predicate, out var _).Select(p => p).ToListAsync();
        }

        private async Task<IList<User>> GetUsersByUserNameAsync(string userName)
        {
            var predicate = PredicateBuilder.New<User>();
            predicate = predicate.And(p => p.UserName == userName);

            return await UnitOfWork.GetRepository<User, int>()
                .GetAll(0, ApiConstants.DefaultListCount, predicate, out var _).Select(p => p).ToListAsync();
        }
    }
}
