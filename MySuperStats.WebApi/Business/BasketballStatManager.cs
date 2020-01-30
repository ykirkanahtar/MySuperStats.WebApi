using System.Collections.Generic;
using AutoMapper;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Constants;
using MySuperStats.WebApi.Data;
using MySuperStats.WebApi.Models;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;
using MySuperStats.Contracts.Responses;
using MySuperStats.Contracts.Utils;
using CustomFramework.BaseWebApi.Utils.Business;
using CustomFramework.BaseWebApi.Utils.Enums;
using CustomFramework.BaseWebApi.Contracts.ApiContracts;
using CustomFramework.BaseWebApi.Utils.Utils;

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

        public Task<IList<BasketballStat>> GetAllByMatchGroupIdAndPlayerIdAsync(int matchGroupId, int playerId)
        {
            return CommonOperationAsync(async () => await _uow.BasketballStats.GetAllByMatchGroupIdAndPlayerIdAsync(matchGroupId, playerId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<IList<BasketballStat>> GetAllByMatchGroupIdAsync(int matchGroupId)
        {
            return CommonOperationAsync(async () => await _uow.BasketballStats.GetAllByMatchGroupIdAsync(matchGroupId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);

        }

        public Task<BasketballStatisticTable> GetTopStats(int matchGroupId)
        {
            return CommonOperation(async () =>
            {
                var players = await _uow.Players.GetAllByMatchGroupIdAsync(matchGroupId);

                var statsResult = await _uow.BasketballStats.GetAllByMatchGroupIdAsync(matchGroupId);
                var stats = statsResult;

                var basketballStatisticTable = new BasketballStatisticTable();

                basketballStatisticTable.Points = _uow.BasketballStats.GetTopPointsStat(players, stats);
                basketballStatisticTable.PointPerMatch = _uow.BasketballStats.GetTopPointsPerMatchStat(players, stats);
                basketballStatisticTable.OnePoint = _uow.BasketballStats.GetTopOnePointStat(players, stats);
                basketballStatisticTable.OnePointPerMatch = _uow.BasketballStats.GetTopOnePointPerMatchStat(players, stats);
                basketballStatisticTable.OnePointRatio = _uow.BasketballStats.GetOnePointRatioStat(players, stats);
                basketballStatisticTable.TwoPoint = _uow.BasketballStats.GetTwoPointStat(players, stats);
                basketballStatisticTable.TwoPointPerMatch = _uow.BasketballStats.GetTwoPointPerMatchStat(players, stats);
                basketballStatisticTable.TwoPointRatio = _uow.BasketballStats.GetTwoPointRatioStat(players, stats);
                basketballStatisticTable.Rebounds = _uow.BasketballStats.GetReboundStat(players, stats);
                basketballStatisticTable.ReboundPerMatch = _uow.BasketballStats.GetReboundPerMatchStat(players, stats);
                basketballStatisticTable.Steals = _uow.BasketballStats.GetStealStat(players, stats);
                basketballStatisticTable.StealsPerMatch = _uow.BasketballStats.GetStealPerMatchStat(players, stats);
                basketballStatisticTable.Turnovers = _uow.BasketballStats.GetTurnoverStat(players, stats);
                basketballStatisticTable.TurnoversPerMatch = _uow.BasketballStats.GetTurnoverPerMatchStat(players, stats);
                basketballStatisticTable.Assist = _uow.BasketballStats.GetAssistStat(players, stats);
                basketballStatisticTable.AssistPerMatch = _uow.BasketballStats.GetAssistPerMatchStat(players, stats);
                basketballStatisticTable.Interrupts = _uow.BasketballStats.GetInterruptStat(players, stats);
                basketballStatisticTable.InterruptPerMatch = _uow.BasketballStats.GetInterruptPerMatchStat(players, stats);
                basketballStatisticTable.Lanes = _uow.BasketballStats.GetLaneStat(players, stats);
                basketballStatisticTable.LanePerMatch = _uow.BasketballStats.GetLanePerMatchStat(players, stats);



                var allPlayersMatchForms = await GetPlayersMatchFormsAsync(matchGroupId, players);

                basketballStatisticTable.Wins = _uow.BasketballStats.GetWinsStat(players, allPlayersMatchForms);
                basketballStatisticTable.WinRatio = _uow.BasketballStats.GetWinRatioStat(players, allPlayersMatchForms);
                basketballStatisticTable.Looses = _uow.BasketballStats.GetLoosesStat(players, allPlayersMatchForms);
                basketballStatisticTable.LooseRatio = _uow.BasketballStats.GetLooseRatioStat(players, allPlayersMatchForms);

                return basketballStatisticTable;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });

        }

        private async Task<List<MatchResultByPlayer>> GetPlayersMatchFormsAsync(int matchGroupId, IEnumerable<Player> players)
        {
            var list = new List<MatchResultByPlayer>();

            foreach (var player in players)
            {
                var playerStatsResult = await _uow.BasketballStats.GetAllByMatchGroupIdAndPlayerIdAsync(matchGroupId, player.Id);
                var playerStats = playerStatsResult;
                var playerStatResponse = Mapper.Map<IList<BasketballStatResponse>>(playerStats);
                var matchResults = playerStatResponse.GetMatchResultByMatchAndPlayerId();
                var matchResutsStrings = new List<string>();
                foreach (var matchResult in matchResults)
                {
                    matchResutsStrings.Add(matchResult.ToString().Substring(0, 1));
                    list.Add(new MatchResultByPlayer(player, matchResult));
                }
            }

            return list;
        }

        private async Task CheckValuesAsync(BasketballStat basketballStat, bool update = false, int? id = null)
        {
            var matchPlayerAndTeamUniqueResult =
                await _uow.BasketballStats.GetByMatchIdTeamIdAndPlayerId(basketballStat.MatchId, basketballStat.TeamId, basketballStat.PlayerId);

            if (update)
                matchPlayerAndTeamUniqueResult.CheckUniqueValueForUpdate((int)id, AppConstants.MatchIdAndTeamIdAndPlayerId);
            else
                matchPlayerAndTeamUniqueResult.CheckUniqueValue(AppConstants.MatchIdAndTeamIdAndPlayerId);
        }
    }
}
