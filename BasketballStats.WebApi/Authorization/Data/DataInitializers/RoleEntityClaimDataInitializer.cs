using BasketballStats.WebApi.Authorization.Enums;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Data.Contracts;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Authorization.Data.DataInitializers
{
    public class RoleEntityClaimDataInitializer : BaseDataInitializer
    {
        public RoleEntityClaimDataInitializer(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task Seed()
        {
            var roleEntityClaims = ConfigHelper.GetSection("RoleEntityClaim");
            foreach (var section in roleEntityClaims.GetChildren())
            {
                var roleName = section.GetValue<string>("RoleName");

                var role = GetRolesByNameAsync(roleName).Result[0];

                var entitiesString = section.GetSection("Entities").Get<string[]>();

                if (entitiesString == null) continue;

                var entities = new List<Entity>();

                if (entitiesString[0] == "All")
                    entities = Enum.GetValues(typeof(Entity)).Cast<Entity>().ToList();
                else
                    entities.AddRange(entitiesString.Select(s => (Entity)Enum.Parse(typeof(Entity), s)));

                foreach (var entity in entities)
                {
                    if (GetRoleEntityClaimsByRoleIdAndEntityAsync(role.Id, entity).Result.Count > 0) continue;

                    var roleEntityClaim = new RoleEntityClaim()
                    {
                        Entity = entity,
                        RoleId = role.Id,
                        CanDelete = true,
                        CanSelect = true,
                        CanCreate = true,
                        CanUpdate = true,
                    };

                    UnitOfWork.GetRepository<RoleEntityClaim, int>().Add(roleEntityClaim);

                    await UnitOfWork.SaveChangesAsync();
                }
            }
        }

        private async Task<IList<RoleEntityClaim>> GetRoleEntityClaimsByRoleIdAndEntityAsync(int roleId, Entity entity)
        {
            return await UnitOfWork.GetRepository<RoleEntityClaim, int>()
                 .GetAll(predicate: p => p.RoleId == roleId && p.Entity == entity).Select(p => p).ToListAsync();
        }

        private async Task<IList<Role>> GetRolesByNameAsync(string name)
        {
            return await UnitOfWork.GetRepository<Role, int>()
                .GetAll(predicate: p => p.RoleName == name).Select(p => p).ToListAsync();
        }

    }
}
