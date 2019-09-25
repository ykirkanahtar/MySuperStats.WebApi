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
        private readonly IMatchManager _matchManager;
        public BasketballStatManager(IMatchManager matchManager, IUnitOfWorkWebApi uow, ILogger<BasketballStatManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
            _matchManager = matchManager;
        }

        public Task<BasketballStat> CreateAsync(BasketballStatRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var basketballStat = Mapper.Map<BasketballStat>(request);
                var result = await CreateUniqueStatAsync(basketballStat);

                await UpdateMatchScores(request.MatchId);

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        private async Task<BasketballStat> CreateUniqueStatAsync(BasketballStat basketballStat)
        {
            await CheckValuesAsync(basketballStat);
            _uow.BasketballStats.Add(basketballStat, GetLoggedInUserId());
            await _uow.SaveChangesAsync();
            return basketballStat;
        }

        private async Task CreateTeamStatsAsync(ICollection<BasketballStatRequestForMultiEntry> teamStats, int matchId)
        {
            foreach (var homeTeamStat in teamStats)
            {
                var basketballStatRequest = Mapper.Map<BasketballStat>(homeTeamStat);
                basketballStatRequest.MatchId = matchId;
                await CreateUniqueStatAsync(basketballStatRequest);
            }
        }

        public Task<int> CreateMultiStats(CreateMatchRequestWithMultiBasketballStats request)
        {
            return CommonOperationAsync(async () =>
            {
                var match = await _matchManager.CreateAsync(request.MatchRequest);

                await CreateTeamStatsAsync(request.HomeTeamStats, match.Id);
                await CreateTeamStatsAsync(request.AwayTeamStats, match.Id);

                await UpdateMatchScores(match.Id);

                return match.Id;
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

                await CheckValuesAsync(result, true, id);

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

        private async Task CheckValuesAsync(BasketballStat basketballStat, bool update = false, int? id = null)
        {
            var matchPlayerAndTeamUniqueResult =
                await _uow.BasketballStats.GetByMatchIdTeamIdAndUserId(basketballStat.MatchId, basketballStat.TeamId, basketballStat.UserId);

            if (update)
                matchPlayerAndTeamUniqueResult.CheckUniqueValueForUpdate((int)id, AppConstants.MatchIdAndTeamIdAndPlayerId);
            else
                matchPlayerAndTeamUniqueResult.CheckUniqueValue(AppConstants.MatchIdAndTeamIdAndPlayerId);
        }
    }
}
