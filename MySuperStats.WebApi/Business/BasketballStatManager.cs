using System.Collections.Generic;
using AutoMapper;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Constants;
using MySuperStats.WebApi.Data;
using MySuperStats.WebApi.Models;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;
using MySuperStats.Contracts.Responses;
using MySuperStats.Contracts.Utils;
using CustomFramework.WebApiUtils.Contracts;

namespace MySuperStats.WebApi.Business
{
    public class BasketballStatManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IBasketballStatManager
    {
        private readonly IUnitOfWorkWebApi _uow;
        public BasketballStatManager(IUnitOfWorkWebApi uow, ILogger<BasketballStatManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<BasketballStat> CreateAsync(BasketballStatRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = Mapper.Map<BasketballStat>(request);

                /**********MatchId, TeamId And PlayerId are unique************/
                /*************************************************************/
                var matchPlayerAndTeamUniqueResult =
                    await _uow.BasketballStats.GetByMatchIdTeamIdAndUserId(result.MatchId, result.TeamId, result.UserId);

                matchPlayerAndTeamUniqueResult.CheckUniqueValue(WebApiResourceConstants.MatchIdAndTeamIdAndPlayerId);
                /**********MatchId, TeamId And PlayerId are unique************/
                /*************************************************************/

                _uow.BasketballStats.Add(result, GetLoggedInUserId());
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
                match.HomeTeamScore = await _uow.BasketballStats.GetTeamScoreByMatchIdAndTeamId(matchId, match.HomeTeamId);
                match.AwayTeamScore = await _uow.BasketballStats.GetTeamScoreByMatchIdAndTeamId(matchId, match.AwayTeamId);
                _uow.Matches.Update(match, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<BasketballStat> UpdateAsync(int id, BasketballStatRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                /**********MatchId, TeamId And PlayerId are unique************/
                /*************************************************************/
                var matchPlayerAndTeamUniqueResult =
                    await _uow.BasketballStats.GetByMatchIdTeamIdAndUserId(result.MatchId, result.TeamId, result.UserId);

                matchPlayerAndTeamUniqueResult.CheckUniqueValueForUpdate(result.Id, WebApiResourceConstants.MatchIdAndTeamIdAndPlayerId);
                /**********MatchId, TeamId And PlayerId are unique************/
                /*************************************************************/

                _uow.BasketballStats.Update(result, GetLoggedInUserId());
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

                _uow.BasketballStats.Delete(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

                await UpdateMatchScores(result.MatchId);

            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<BasketballStat> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.BasketballStats.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<IList<BasketballStat>> GetAllByMatchIdAsync(int matchId)
        {
            return CommonOperationAsync(async () => await _uow.BasketballStats.GetAllByMatchIdAsync(matchId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<IList<BasketballStat>> GetAllByMatchGroupIdAndUserIdAsync(int matchGroupId, int userId)
        {
            return CommonOperationAsync(async () => await _uow.BasketballStats.GetAllByMatchGroupIdAndUserIdAsync(matchGroupId, userId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<IList<BasketballStat>> GetAllByMatchGroupIdAsync(int matchGroupId)
        {
            return CommonOperationAsync(async () => await _uow.BasketballStats.GetAllByMatchGroupIdAsync(matchGroupId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);

        }

        public Task<BasketballStatisticTable> GetTopStats(int matchGroupId)
        {
            return CommonOperation(async () =>
            {
                var users = await _uow.Users.GetAllAsync();

                var statsResult = await _uow.BasketballStats.GetAllByMatchGroupIdAsync(matchGroupId);
                var stats = statsResult;

                var basketballStatisticTable = new BasketballStatisticTable
                {
                    Points = _uow.BasketballStats.GetTopPointsStat(users, stats),
                    PointPerMatch = _uow.BasketballStats.GetTopPointsPerMatchStat(users, stats),
                    OnePoint = _uow.BasketballStats.GetTopOnePointStat(users, stats),
                    OnePointPerMatch = _uow.BasketballStats.GetTopOnePointPerMatchStat(users, stats),
                    OnePointRatio = _uow.BasketballStats.GetOnePointRatioStat(users, stats),
                    TwoPoint = _uow.BasketballStats.GetTwoPointStat(users, stats),
                    TwoPointPerMatch = _uow.BasketballStats.GetTwoPointPerMatchStat(users, stats),
                    TwoPointRatio = _uow.BasketballStats.GetTwoPointRatioStat(users, stats),
                    Rebounds = _uow.BasketballStats.GetReboundStat(users, stats),
                    ReboundPerMatch = _uow.BasketballStats.GetReboundPerMatchStat(users, stats),
                    Steals = _uow.BasketballStats.GetStealStat(users, stats),
                    StealsPerMatch = _uow.BasketballStats.GetStealPerMatchStat(users, stats),
                    Turnovers = _uow.BasketballStats.GetTurnoverStat(users, stats),
                    TurnoversPerMatch = _uow.BasketballStats.GetTurnoverPerMatchStat(users, stats),
                    Assist = _uow.BasketballStats.GetAssistStat(users, stats),
                    AssistPerMatch = _uow.BasketballStats.GetAssistPerMatchStat(users, stats),
                    Interrupts = _uow.BasketballStats.GetInterruptStat(users, stats),
                    InterruptPerMatch = _uow.BasketballStats.GetInterruptPerMatchStat(users, stats)
                };

                var allUsersMatchForms = await GetUsersMatchFormsAsync(matchGroupId, users);

                basketballStatisticTable.Wins = _uow.BasketballStats.GetWinsStat(users, allUsersMatchForms);
                basketballStatisticTable.WinRatio = _uow.BasketballStats.GetWinRatioStat(users, allUsersMatchForms);
                basketballStatisticTable.Looses = _uow.BasketballStats.GetLoosesStat(users, allUsersMatchForms);
                basketballStatisticTable.LooseRatio = _uow.BasketballStats.GetLooseRatioStat(users, allUsersMatchForms);

                return basketballStatisticTable;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });

        }

        private async Task<List<MatchResultByUser>> GetUsersMatchFormsAsync(int matchGroupId, IEnumerable<User> users)
        {
            var list = new List<MatchResultByUser>();

            foreach (var user in users)
            {
                var userStatsResult = await _uow.BasketballStats.GetAllByMatchGroupIdAndUserIdAsync(matchGroupId, user.Id);
                var userStats = userStatsResult;
                var userStatResponse = Mapper.Map<IList<BasketballStatResponse>>(userStats);
                var matchResults = userStatResponse.GetMatchResultByMatchAndUserId();
                var matchResutsStrings = new List<string>();
                foreach (var matchResult in matchResults)
                {
                    matchResutsStrings.Add(matchResult.ToString().Substring(0, 1));
                    list.Add(new MatchResultByUser(user, matchResult));
                }
            }

            return list;
        }
    }
}
