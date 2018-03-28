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
    public class ClientApplicationUtilManager : BusinessManagerBase<ClientApplicationUtilManager, ApiRequest>, IClientApplicationUtilManager
    {
        public ClientApplicationUtilManager(IUnitOfWork unitOfWork, ILogger<ClientApplicationUtilManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor) : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<ClientApplicationUtil> CreateAsync(ClientApplicationUtilRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<ClientApplicationUtil>(request);

                UnitOfWork.GetRepository<ClientApplicationUtil, int>().Add(result);
                await UnitOfWork.SaveChangesAsync();
                return result;

            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<ClientApplicationUtil> UpdateSpecialValueAsync(int id, string specialValue)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                result.SpecialValue = specialValue;
                
                UnitOfWork.GetRepository<ClientApplicationUtil, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();
                return result;

            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<ClientApplicationUtil, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<ClientApplicationUtil> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await UnitOfWork.GetRepository<ClientApplicationUtil, int>().GetAsync(p => p.Id == id);
                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ClientApplicationUtil> GetByClientApplicationIdAsync(int clientApplicationId)
        {
            return CommonOperationAsync(async () =>
            {

                var predicate = PredicateBuilder.New<ClientApplicationUtil>();
                predicate = predicate.And(p => p.ClientApplicationId == clientApplicationId);

                var result = await UnitOfWork.GetRepository<ClientApplicationUtil, int>()
                    .GetAll(0, ApiConstants.DefaultListCount, predicate, out var _)
                    .Select(p => p)
                    .ToListAsync();

                BusinessUtil.UniqueGenericListChecker(result, GetType().Name);
                return result[0];
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }
    }

}
