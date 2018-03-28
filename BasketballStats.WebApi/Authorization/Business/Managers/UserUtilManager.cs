using AutoMapper;
using BasketballStats.WebApi.Authorization.Business.Contracts;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Business;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Data.Contracts;
using BasketballStats.WebApi.Enums;
using BasketballStats.WebApi.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Authorization.Business.Managers
{
    public class UserUtilManager : BusinessManagerBase<UserUtilManager, ApiRequest>, IUserUtilManager
    {
        public UserUtilManager(IUnitOfWork unitOfWork, ILogger<UserUtilManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor) : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<UserUtil> CreateAsync(UserUtilRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<UserUtil>(request);

                UnitOfWork.GetRepository<UserUtil, int>().Add(result);
                await UnitOfWork.SaveChangesAsync();
                return result;

            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<UserUtil> UpdateSpecialValueAsync(int id, string specialValue)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                result.SpecialValue = specialValue;

                UnitOfWork.GetRepository<UserUtil, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<UserUtil, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<UserUtil> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await UnitOfWork.GetRepository<UserUtil, int>().GetAsync(p => p.Id == id);
                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<UserUtil> GetByUserIdAsync(int userId)
        {
            return CommonOperationAsync(async () =>
            {

                var predicate = PredicateBuilder.New<UserUtil>();
                predicate = predicate.And(p => p.UserId == userId);

                var result = await UnitOfWork.GetRepository<UserUtil, int>()
                    .GetAll(0, ApiConstants.DefaultListCount, predicate, out var _)
                    .Select(p => p)
                    .ToListAsync();

                BusinessUtil.UniqueGenericListChecker(result, GetType().Name);
                return result[0];
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }
    }
}
