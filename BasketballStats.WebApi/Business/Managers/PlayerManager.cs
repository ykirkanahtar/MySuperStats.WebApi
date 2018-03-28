using AutoMapper;
using BasketballStats.WebApi.Business.Contracts;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Data.Contracts;
using BasketballStats.WebApi.Enums;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Models;
using BasketballStats.WebApi.RequestModels;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Business.Managers
{
    public class PlayerManager : BusinessManagerBase<PlayerManager, ApiRequest>, IPlayerManager
    {
        public PlayerManager(IUnitOfWork unitOfWork, ILogger<PlayerManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {
        }

        public Task<Player> CreateAsync(PlayerRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<Player>(request);

                UnitOfWork.GetRepository<Player, int>().Add(result);
                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Player> UpdateAsync(int id, PlayerRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                UnitOfWork.GetRepository<Player, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<Player, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Player> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
                {
                    var result = await UnitOfWork.GetRepository<Player, int>().GetAsync(p => p.Id == id);
                    return result;
                }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Player>> GetAllByNameAsync(string name)
        {
            return CommonOperationAsync(async () =>
            {
                var predicate = PredicateBuilder.New<Player>();
                predicate = predicate.And(p => p.Name == name);

                return new CustomEntityList<Player>
                {
                    EntityList = await UnitOfWork.GetRepository<Player, int>().GetAll(predicate, out var count).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<CustomEntityList<Player>> GetAllBySurnameAsync(string surname)
        {
            return CommonOperationAsync(async () =>
            {
                var predicate = PredicateBuilder.New<Player>();
                predicate = predicate.And(p => p.Surname == surname);

                return new CustomEntityList<Player>
                {
                    EntityList = await UnitOfWork.GetRepository<Player, int>().GetAll(predicate, out var count).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<CustomEntityList<Player>> GetAllByNameAndSurnameAsync(string name, string surname)
        {
            return CommonOperationAsync(async () =>
            {
                var predicate = PredicateBuilder.New<Player>();
                predicate = predicate.And(p => p.Name == name);
                predicate = predicate.And(p => p.Surname == surname);

                return new CustomEntityList<Player>
                {
                    EntityList = await UnitOfWork.GetRepository<Player, int>().GetAll(predicate, out var count).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<CustomEntityList<Player>> GetAllAsync()
        {
            return CommonOperationAsync(async () => new CustomEntityList<Player>
            {
                EntityList = await UnitOfWork.GetRepository<Player, int>().GetAll(out var count).ToListAsync(),
                Count = count,
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }
    }
}
