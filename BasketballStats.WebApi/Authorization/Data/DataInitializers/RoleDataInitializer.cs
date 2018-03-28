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
    public class RoleDataInitializer : BaseDataInitializer
    {
        public RoleDataInitializer(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task Seed()
        {
            var roles = ConfigHelper.GetSection("Roles");
            foreach (var section in roles.GetChildren())
            {
                var name = section.GetValue<string>("Name");

                if (GetRolesByNameAsync(name).Result.Count > 0) continue;

                var role = new Role
                {
                    RoleName = name,
                };

                UnitOfWork.GetRepository<Role, int>().Add(role);
                await UnitOfWork.SaveChangesAsync();
            }
        }

        private async Task<IList<Role>> GetRolesByNameAsync(string name)
        {
            var predicate = PredicateBuilder.New<Role>();
            predicate = predicate.And(p => p.RoleName == name);

            return await UnitOfWork.GetRepository<Role, int>()
                .GetAll(0, ApiConstants.DefaultListCount, predicate, out var _).Select(p => p).ToListAsync();
        }
    }
}
