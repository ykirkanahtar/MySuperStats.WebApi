using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using BasketballStats.Contracts.Requests;
using BasketballStats.WebApi.Constants;
using BasketballStats.WebApi.Data;
using BasketballStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Business;
using CustomFramework.WebApiUtils.Authorization.Contracts;
using CustomFramework.WebApiUtils.Authorization.Utils;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;

namespace BasketballStats.WebApi.Business
{
    public class MatchManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IMatchManager
    {
        private readonly IUnitOfWorkWebApi _uow;

        public MatchManager(IUnitOfWorkWebApi uow, ILogger<MatchManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<Match> CreateAsync(MatchRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<Match>(request);

                /**************MatchDate And Order are unique*****************/
                /*************************************************************/
                var matchDateAndOrderUniqueResult =
                    await _uow.Matches.GetByMatchDateAndOrderAsync(result.MatchDate, result.Order);

                matchDateAndOrderUniqueResult.CheckUniqueValue(WebApiResourceConstants.MatchDateAndOrder);
                /**************MatchDate And Order are unique*****************/
                /*************************************************************/

                SameValueCheckForTeam1AndTeam2(result);

                _uow.Matches.Add(result);
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Match> UpdateAsync(int id, MatchRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                /**************MatchDate And Order are unique*****************/
                /*************************************************************/
                var matchDateAndOrderUniqueResult =
                    await _uow.Matches.GetByMatchDateAndOrderAsync(result.MatchDate, result.Order);

                matchDateAndOrderUniqueResult.CheckUniqueValueForUpdate(result.Id, WebApiResourceConstants.MatchDateAndOrder);
                /**************MatchDate And Order are unique*****************/
                /*************************************************************/

                SameValueCheckForTeam1AndTeam2(result);

                _uow.Matches.Update(result);
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.Matches.Delete(result);
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Match> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.Matches.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ICustomList<Match>> GetAllAsync()
        {
            return CommonOperationAsync(async () => await _uow.Matches.GetAllAsync(), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        private static void SameValueCheckForTeam1AndTeam2(Match entity)
        {
            if (entity.HomeTeamId == entity.AwayTeamId)
                entity.CheckDuplicatationForUniqueValue(WebApiResourceConstants.Team1AndTeam2);
        }

    }
}
