using AutoMapper;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Constants;
using MySuperStats.WebApi.Data;
using MySuperStats.WebApi.Models;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MySuperStats.WebApi.Business
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
            return CommonOperationAsync(async () =>
            {
                var result = Mapper.Map<Match>(request);

                await CheckValuesAsync(request);

                _uow.Matches.Add(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Match> UpdateAsync(int id, MatchRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                await CheckValuesAsync(request, true, id);

                _uow.Matches.Update(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.Matches.Delete(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Match> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.Matches.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<IList<Match>> GetAllByMatchGroupIdAsync(int matchGroupId)
        {
            return CommonOperationAsync(async () => await _uow.Matches.GetAllByMatchGroupIdAsync(matchGroupId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<IList<Match>> GetMatchForMainScreen(int matchGroupId)
        {
            return CommonOperationAsync(async () => await _uow.Matches.GetMatchForMainScreen(matchGroupId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<Match> GetMatchDetailBasketballStats(int matchId)
        {
            return CommonOperationAsync(async () => await _uow.Matches.GetMatchDetailBasketballStats(matchId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<Match> GetMatchDetailFootballStats(int matchId)
        {
            return CommonOperationAsync(async () => await _uow.Matches.GetMatchDetailFootballStats(matchId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }        

        private async Task CheckValuesAsync(MatchRequest request, bool update = false, int? id = null)
        {
            (await _uow.MatchGroups.GetByIdAsync(request.MatchGroupId)).CheckRecordIsExist(nameof(MatchGroup));

            var matchDateAndOrderUniqueResult =
                await _uow.Matches.GetByMatchDateAndOrderAsync(request.MatchDate, request.Order);

            if (update)
                matchDateAndOrderUniqueResult.CheckUniqueValueForUpdate((int)id, AppConstants.MatchDateAndOrder);
            else
                matchDateAndOrderUniqueResult.CheckUniqueValue(AppConstants.MatchDateAndOrder);

            if (request.HomeTeamId == request.AwayTeamId)
                request.CheckDuplicatationForUniqueValue(AppConstants.Team1AndTeam2);                
        }
    }
}
