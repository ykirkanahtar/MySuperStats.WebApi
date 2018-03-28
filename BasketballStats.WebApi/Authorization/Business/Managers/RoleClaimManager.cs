using AutoMapper;
using BasketballStats.WebApi.Authorization.Business.Contracts;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Business;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Data.Contracts;
using BasketballStats.WebApi.Enums;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Authorization.Business.Managers
{
    public class RoleClaimManager : BusinessManagerBase<RoleClaimManager, ApiRequest>, IRoleClaimManager
    {
        public RoleClaimManager(IUnitOfWork unitOfWork, ILogger<RoleClaimManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor) : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<bool> AddRoleToClaimAsync(RoleClaimRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<RoleClaim>(request);

                /******************References Table Check Values****************/
                /***************************************************************/
                await BusinessUtil.GetByIntIdChecker<Role, IRepository<Role>>(result.RoleId, UnitOfWork.GetRepository<Role, int>());

                await BusinessUtil.GetByIntIdChecker<Claim, IRepository<Claim>>(result.ClaimId, UnitOfWork.GetRepository<Claim, int>());
                /***************************************************************/
                /***************************************************************/

                await UniqueCheckForRoleClaimAsync(result);

                UnitOfWork.GetRepository<RoleClaim, int>().Add(result);

                await UnitOfWork.SaveChangesAsync();
                return true;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<bool> RemoveRoleFromClaimAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<RoleClaim, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
                return true;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<RoleClaim> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await UnitOfWork.GetRepository<RoleClaim, int>().GetAsync(p => p.Id == id);
                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
            BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<bool> RolesAreAuthorizedForClaimAsync(IList<Role> roles, int claimId)
        {
            return CommonOperationAsync(async () =>
            {
                var predicate = PredicateBuilder.New<RoleClaim>();
                predicate = roles.Aggregate(predicate, (current, role) => current.Or(p => p.RoleId == role.Id));
                predicate = predicate.And(p => p.ClaimId == claimId);

                return (await UnitOfWork.GetRepository<RoleClaim, int>().GetAll(predicate, out _).Select(p => p).ToListAsync())
                       .Count > 0;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<CustomEntityList<Claim>> GetClaimsByRoleIdAsync(int roleId)
        {
            return CommonOperationAsync(async () =>
            {
                var predicate = PredicateBuilder.New<RoleClaim>();
                predicate = predicate.And(p => p.RoleId == roleId);

                return new CustomEntityList<Claim>
                {
                    EntityList = await UnitOfWork.GetRepository<RoleClaim, int>().GetAll(predicate, out var count).Select(p => p.Claim).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<CustomEntityList<Role>> GetRolesByClaimIdAsync(int claimId)
        {
            return CommonOperationAsync(async () =>
            {
                var predicate = PredicateBuilder.New<RoleClaim>();
                predicate = predicate.And(p => p.ClaimId == claimId);

                return new CustomEntityList<Role>
                {
                    EntityList = await UnitOfWork.GetRepository<RoleClaim, int>().GetAll(predicate, out var count).Select(p => p.Role).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        #region Validations
        private async Task UniqueCheckForRoleClaimAsync(RoleClaim entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<RoleClaim>();
            predicate = predicate.And(p => p.RoleId == entity.RoleId);
            predicate = predicate.And(p => p.ClaimId == entity.ClaimId);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<RoleClaim, int>().GetAll(0, ApiConstants.DefaultListCount, predicate, out var _).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, GetType().Name);
        }

        #endregion

    }
}
