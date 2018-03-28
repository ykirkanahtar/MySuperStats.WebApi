using AutoMapper;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Data.Contracts;
using BasketballStats.WebApi.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Business
{
    public class BusinessManagerBase<TManager, TApiRequest> where TManager : IBusinessManager where TApiRequest : IApiRequest
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly ILogger<TManager> Logger;
        protected readonly IMapper Mapper;
        protected readonly IApiRequest ApiRequestAccessor;

        public BusinessManagerBase(IUnitOfWork unitOfWork, ILogger<TManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
        {
            UnitOfWork = unitOfWork;
            Logger = logger;
            Mapper = mapper;
            ApiRequestAccessor = apiRequestAccessor.GetApiRequest<TApiRequest>();
        }

        protected async Task<T> CommonOperationAsync<T>(Func<Task<T>> func, BusinessBaseRequest businessBaseRequest)
        {
            try
            {
                var result = await func.Invoke();
                return result;
            }
            catch (Exception ex)
            {
                Logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
                throw;
            }
        }

        protected async Task<T> CommonOperationAsync<T>(Func<Task<T>> func, BusinessBaseRequest businessBaseRequest, BusinessUtilMethod businessUtilMethod, string additionalInfo, bool critical = false)
        {
            try
            {
                var result = await func.Invoke();
                BusinessUtilMethodExecute.Execute(businessUtilMethod, result, additionalInfo, critical);

                return result;
            }
            catch (Exception ex)
            {
                Logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
                throw;
            }
        }

        protected async Task<T> CommonOperationWithTransactionAsync<T>(Func<Task<T>> func, BusinessBaseRequest businessBaseRequest)
        {
            //TODO .Net Core Transaction yapısı desteklendiğinde bu kod açılacak.
            // Alınan hata : Nested/Concurrent transactions aren't supported
            //using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            //{
            try
            {
                var result = await func.Invoke();
                //scope.Complete();
                return result;
            }
            catch (Exception ex)
            {
                Logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
                throw;
            }
            //}
        }

        protected async Task CommonOperationWithTransactionAsync(Func<Task> func, BusinessBaseRequest businessBaseRequest)
        {
            try
            {
                //TODO .Net Core Transaction yapısı desteklendiğinde bu kod açılacak.
                // Alınan hata : Nested/Concurrent transactions aren't supported
                //using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                //{
                await func.Invoke();
                //scope.Complete();
                //}
            }
            catch (Exception ex)
            {
                Logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
                throw;
            }
        }
    }
}