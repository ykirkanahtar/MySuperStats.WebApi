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
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Authorization.Business.Managers
{
    public class RoleManager : BusinessManagerBase<RoleManager, ApiRequest>, IRoleManager
    {
        public RoleManager(IUnitOfWork unitOfWork, ILogger<RoleManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor) : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<Role> CreateAsync(RoleRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<Role>(request);

                await UniqueCheckForRoleNameAsync(result);

                UnitOfWork.GetRepository<Role, int>().Add(result);

                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Role> UpdateAsync(int id, RoleRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                await UniqueCheckForRoleNameAsync(result, id);

                UnitOfWork.GetRepository<Role, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<Role, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Role> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await UnitOfWork.GetRepository<Role, int>().GetAsync(p => p.Id == id);
                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
            BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<Role> GetByNameAsync(string name)
        {
            return CommonOperationAsync(async () =>
            {
                var predicate = PredicateBuilder.New<Role>();
                predicate = predicate.And(p => p.RoleName == name);

                var result = await UnitOfWork.GetRepository<Role, int>().GetAll(0, ApiConstants.DefaultListCount, predicate, out var _).Select(p => p).ToListAsync();

                BusinessUtil.UniqueGenericListChecker(result, GetType().Name);
                return result[0];
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Role>> GetAllAsync()
        {
            return CommonOperationAsync(async () => new CustomEntityList<Role>
            {
                EntityList = await UnitOfWork.GetRepository<Role, int>().GetAll(out var count).Select(p => p).ToListAsync(),
                Count = count,
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        #region Validations
        private async Task UniqueCheckForRoleNameAsync(Role entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<Role>();
            predicate = predicate.And(p => p.RoleName == entity.RoleName);


            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<Role, int>().GetAll(0, ApiConstants.DefaultListCount, predicate, out var _).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, ResourceConstants.RoleName);
        }

        #endregion
    }
}
