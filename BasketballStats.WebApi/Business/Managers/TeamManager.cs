using AutoMapper;
using BasketballStats.WebApi.Business.Contracts;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Data.Contracts;
using BasketballStats.WebApi.Enums;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Models;
using BasketballStats.WebApi.RequestModels;
using BasketballStats.WebApi.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Business.Managers
{
    public class TeamManager : BusinessManagerBase<TeamManager, ApiRequest>, ITeamManager
    {
        public TeamManager(IUnitOfWork unitOfWork, ILogger<TeamManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {
        }

        public Task<Team> CreateAsync(TeamRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<Team>(request);
                await UniqueCheckForNameAsync(result);

                UnitOfWork.GetRepository<Team, int>().Add(result);
                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Team> UpdateAsync(int id, TeamRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                await UniqueCheckForNameAsync(result, id);

                UnitOfWork.GetRepository<Team, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<Team, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Team> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
                {
                    var result = await UnitOfWork.GetRepository<Team, int>().GetAsync(p => p.Id == id);
                    return result;
                }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Team>> GetAllAsync()
        {
            return CommonOperationAsync(async () => new CustomEntityList<Team>
            {
                EntityList = await UnitOfWork.GetRepository<Team, int>().GetAll(out var count).ToListAsync(),
                Count = count,
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        #region Validations
        private async Task UniqueCheckForNameAsync(Team entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<Team>();
            predicate = predicate.And(p => p.Name == entity.Name);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<Team, int>().GetAll(0, ApiConstants.DefaultListCount, predicate, out var _).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, ResourceConstants.Name);
        }
        #endregion
    }
}
