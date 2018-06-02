using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using BasketballStats.Contracts.Requests;
using BasketballStats.WebApi.Data;
using BasketballStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Business;
using CustomFramework.WebApiUtils.Authorization.Contracts;
using CustomFramework.WebApiUtils.Authorization.Utils;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Enums;
using Microsoft.Extensions.Logging;

namespace BasketballStats.WebApi.Business
{
    public class PlayerManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IPlayerManager
    {
        private readonly IUnitOfWorkWebApi _uow;
        public PlayerManager(IUnitOfWorkWebApi uow, ILogger<PlayerManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<Player> CreateAsync(PlayerRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<Player>(request);

                _uow.Players.Add(result);
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Player> UpdateAsync(int id, PlayerRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                _uow.Players.Update(result);
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.Players.Delete(result);
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Player> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.Players.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ICustomList<Player>> GetAllAsync()
        {
            return CommonOperationAsync(async () => await _uow.Players.GetAllAsync(), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }
    }
}
