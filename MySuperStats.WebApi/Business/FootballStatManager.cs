using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Constants;
using MySuperStats.WebApi.Data;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Business
{
    public class FootballStatManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IFootballStatManager
    {
        private readonly IUnitOfWorkWebApi _uow;
        public FootballStatManager(IUnitOfWorkWebApi uow, ILogger<FootballStatManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<FootballStat> CreateAsync(FootballStatRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = Mapper.Map<FootballStat>(request);

                /**********MatchId, TeamId And PlayerId are unique************/
                /*************************************************************/
                var matchPlayerAndTeamUniqueResult =
                    await _uow.FootballStats.GetByMatchIdTeamIdAndPlayerId(result.MatchId, result.TeamId, result.PlayerId);

                matchPlayerAndTeamUniqueResult.CheckUniqueValue(AppConstants.MatchIdAndTeamIdAndPlayerId);
                /**********MatchId, TeamId And PlayerId are unique************/
                /*************************************************************/

                _uow.FootballStats.Add(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

                await UpdateMatchScores(request.MatchId);

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        private Task UpdateMatchScores(int matchId)
        {
            return CommonOperationAsync(async () =>
            {
                var match = _uow.Matches.GetById(matchId);
                match.HomeTeamScore = await _uow.FootballStats.GetTeamScoreByMatchIdAndTeamId(matchId, match.HomeTeamId);
                match.AwayTeamScore = await _uow.FootballStats.GetTeamScoreByMatchIdAndTeamId(matchId, match.AwayTeamId);
                _uow.Matches.Update(match, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<FootballStat> UpdateAsync(int id, FootballStatRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                /**********MatchId, TeamId And PlayerId are unique************/
                /*************************************************************/
                var matchPlayerAndTeamUniqueResult =
                    await _uow.FootballStats.GetByMatchIdTeamIdAndPlayerId(result.MatchId, result.TeamId, result.PlayerId);

                matchPlayerAndTeamUniqueResult.CheckUniqueValueForUpdate(result.Id, AppConstants.MatchIdAndTeamIdAndPlayerId);
                /**********MatchId, TeamId And PlayerId are unique************/
                /*************************************************************/

                _uow.FootballStats.Update(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

                await UpdateMatchScores(request.MatchId);

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.FootballStats.Delete(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

                await UpdateMatchScores(result.MatchId);

            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<FootballStat> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.FootballStats.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<IList<FootballStat>> GetAllByMatchIdAsync(int matchId)
        {
            return CommonOperationAsync(async () => await _uow.FootballStats.GetAllByMatchIdAsync(matchId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<IList<FootballStat>> GetAllByPlayerIdAsync(int playerId)
        {
            return CommonOperationAsync(async () => await _uow.FootballStats.GetAllByPlayerIdAsync(playerId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<IList<FootballStat>> GetAllAsync()
        {
            return CommonOperationAsync(async () => await _uow.FootballStats.GetAllAsync(), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);

        }
    }
}