using AutoMapper;
using BasketballStats.Contracts.Requests;
using BasketballStats.WebApi.Constants;
using BasketballStats.WebApi.Data;
using BasketballStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Contracts;

namespace BasketballStats.WebApi.Business
{
    public class StatManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IStatManager
    {
        private readonly IUnitOfWorkWebApi _uow;
        public StatManager(IUnitOfWorkWebApi uow, ILogger<StatManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<Stat> CreateAsync(StatRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = Mapper.Map<Stat>(request);

                /**********MatchId, TeamId And PlayerId are unique************/
                /*************************************************************/
                var matchPlayerAndTeamUniqueResult =
                    await _uow.Stats.GetByMatchIdTeamIdAndPlayerId(result.MatchId, result.TeamId, result.PlayerId);

                matchPlayerAndTeamUniqueResult.CheckUniqueValue(WebApiResourceConstants.MatchIdAndTeamIdAndPlayerId);
                /**********MatchId, TeamId And PlayerId are unique************/
                /*************************************************************/

                _uow.Stats.Add(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Stat> UpdateAsync(int id, StatRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                /**********MatchId, TeamId And PlayerId are unique************/
                /*************************************************************/
                var matchPlayerAndTeamUniqueResult =
                    await _uow.Stats.GetByMatchIdTeamIdAndPlayerId(result.MatchId, result.TeamId, result.PlayerId);

                matchPlayerAndTeamUniqueResult.CheckUniqueValueForUpdate(result.Id, WebApiResourceConstants.MatchIdAndTeamIdAndPlayerId);
                /**********MatchId, TeamId And PlayerId are unique************/
                /*************************************************************/

                _uow.Stats.Update(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.Stats.Delete(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Stat> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.Stats.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ICustomList<Stat>> GetAllByMatchIdAsync(int matchId)
        {
            return CommonOperationAsync(async () => await _uow.Stats.GetAllByMatchIdAsync(matchId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<ICustomList<Stat>> GetAllByPlayerIdAsync(int playerId)
        {
            return CommonOperationAsync(async () => await _uow.Stats.GetAllByPlayerIdAsync(playerId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);

        }

        public Task<ICustomList<Stat>> GetAllAsync()
        {
            return CommonOperationAsync(async () => await _uow.Stats.GetAllAsync(), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);

        }

    }
}
