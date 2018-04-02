using AutoMapper;
using BasketballStats.WebApi.Business.Contracts;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Data.Contracts;
using BasketballStats.WebApi.Enums;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Models;
using BasketballStats.WebApi.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BasketballStats.Contracts.Requests;

namespace BasketballStats.WebApi.Business.Managers
{
    public class MatchManager : BusinessManagerBase<MatchManager, ApiRequest>, IMatchManager
    {
        public MatchManager(IUnitOfWork unitOfWork, ILogger<MatchManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<Match> CreateAsync(MatchRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<Match>(request);

                await UniqueCheckForMatchDateAndOrderAsync(result);
                SameValueCheckForTeam1AndTeam2(result);

                UnitOfWork.GetRepository<Match, int>().Add(result);
                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Match> UpdateAsync(int id, MatchRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                await UniqueCheckForMatchDateAndOrderAsync(result, id);
                SameValueCheckForTeam1AndTeam2(result);

                UnitOfWork.GetRepository<Match, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<Match, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Match> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
                {
                    return await UnitOfWork.GetRepository<Match, int>().GetAll(predicate: p => p.Id == id, include: source => source.Include(p => p.Stats).Include(p => p.HomeTeam).Include(p => p.AwayTeam)).FirstOrDefaultAsync();
                }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Match>> GetAllAsync()
        {
            return CommonOperationAsync(async () => new CustomEntityList<Match>
            {
                EntityList = await UnitOfWork.GetRepository<Match, int>().GetAll(out var count, include: source => source.Include(p => p.HomeTeam).Include(p => p.AwayTeam)).ToListAsync(),
                Count = count,
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }


        #region Validations
        private async Task UniqueCheckForMatchDateAndOrderAsync(Match entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<Match>();
            predicate = predicate.And(p => p.MatchDate == entity.MatchDate.Date);
            predicate = predicate.And(p => p.Order == entity.Order);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<Match, int>().GetAll(predicate: predicate).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, ResourceConstants.MatchDateAndOrder);
        }

        private void SameValueCheckForTeam1AndTeam2(Match entity)
        {
            if (entity.HomeTeamId == entity.AwayTeamId)
                BusinessUtil.CheckDuplicatationForUniqueValue(entity, ResourceConstants.Team1AndTeam2);
        }

        #endregion

    }
}
