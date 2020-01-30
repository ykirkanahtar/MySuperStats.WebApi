using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using MySuperStats.Contracts.Utils;
using CustomFramework.BaseWebApi.Utils.Utils;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Constants;
using MySuperStats.WebApi.Data;
using MySuperStats.WebApi.Models;
using CustomFramework.BaseWebApi.Utils.Business;
using CustomFramework.BaseWebApi.Utils.Enums;
using CustomFramework.BaseWebApi.Contracts.ApiContracts;

namespace MySuperStats.WebApi.Business
{
    public class FootballStatManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IFootballStatManager
    {
        private readonly IUnitOfWorkWebApi _uow;
        private readonly IMatchManager _matchManager;
        public FootballStatManager(IUnitOfWorkWebApi uow, ILogger<FootballStatManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor, IMatchManager matchManager)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
            _matchManager = matchManager;
        }

        public Task<FootballStat> CreateAsync(FootballStatRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var footballStat = Mapper.Map<FootballStat>(request);
                var result = await CreateUniqueStatAsync(footballStat);

                await UpdateMatchScores(request.MatchId);

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        private async Task<FootballStat> CreateUniqueStatAsync(FootballStat footballStat)
        {
            await CheckValuesAsync(footballStat);
            _uow.FootballStats.Add(footballStat, GetLoggedInUserId());
            await _uow.SaveChangesAsync();
            return footballStat;
        }

        private async Task CreateTeamStatsAsync(ICollection<FootballStatRequestForMultiEntry> teamStats, int matchId)
        {
            foreach (var homeTeamStat in teamStats)
            {
                var footballStatRequest = Mapper.Map<FootballStat>(homeTeamStat);
                footballStatRequest.MatchId = matchId;
                await CreateUniqueStatAsync(footballStatRequest);
            }
        }

        public Task<int> CreateMultiStats(CreateMatchRequestWithMultiFootballStats request)
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

                await CheckValuesAsync(result, true, id);

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

        public Task<IList<FootballStat>> GetAllByMatchGroupIdAndPlayerIdAsync(int matchGroupId, int playerId)
        {
            return CommonOperationAsync(async () => await _uow.FootballStats.GetAllByMatchGroupIdAndPlayerIdAsync(matchGroupId, playerId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<IList<FootballStat>> GetAllByMatchGroupIdAsync(int matchGroupId)
        {
            return CommonOperationAsync(async () => await _uow.FootballStats.GetAllByMatchGroupIdAsync(matchGroupId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);

        }

        public Task<FootballStatisticTable> GetTopStats(int matchGroupId)
        {
            return CommonOperation(async () =>
            {
                var players = await _uow.Players.GetAllByMatchGroupIdAsync(matchGroupId);

                var statsResult = await _uow.FootballStats.GetAllByMatchGroupIdAsync(matchGroupId);
                var stats = statsResult;

                var footballStatisticTable = new FootballStatisticTable();

                footballStatisticTable.Goals = _uow.FootballStats.GetTopGoalsStat(players, stats);
                footballStatisticTable.GoalPerMatch = _uow.FootballStats.GetTopGoalsPerMatchStat(players, stats);

                footballStatisticTable.OwnGoals = _uow.FootballStats.GetOwnGoalStat(players, stats);
                footballStatisticTable.OwnGoalPerMatch = _uow.FootballStats.GetOwnGoalPerMatchStat(players, stats);
                footballStatisticTable.PenaltyScores = _uow.FootballStats.GetPenaltyScoreStat(players, stats);
                footballStatisticTable.PenaltyScorePerMatch = _uow.FootballStats.GetPenaltyScorePerMatchStat(players, stats);
                footballStatisticTable.MissedPenalties = _uow.FootballStats.GetMissedPenaltyStat(players, stats);
                footballStatisticTable.MissedPenaltyPerMatch = _uow.FootballStats.GetMissedPenaltyPerMatchStat(players, stats);
                footballStatisticTable.Assist = _uow.FootballStats.GetAssistStat(players, stats);
                footballStatisticTable.AssistPerMatch = _uow.FootballStats.GetAssistPerMatchStat(players, stats);
                footballStatisticTable.SaveGoals = _uow.FootballStats.GetSaveGoalStat(players, stats);
                footballStatisticTable.SaveGoalPerMatch = _uow.FootballStats.GetSaveGoalPerMatchStat(players, stats);
                footballStatisticTable.ConcedeGoals = _uow.FootballStats.GetConcedeGoalStat(players, stats);
                footballStatisticTable.ConcedeGoalPerMatch = _uow.FootballStats.GetConcedeGoalPerMatchStat(players, stats);

                var allPlayersMatchForms = await GetPlayersMatchFormsAsync(matchGroupId, players);

                footballStatisticTable.Wins = _uow.FootballStats.GetWinsStat(players, allPlayersMatchForms);
                footballStatisticTable.WinRatio = _uow.FootballStats.GetWinRatioStat(players, allPlayersMatchForms);
                footballStatisticTable.Looses = _uow.FootballStats.GetLoosesStat(players, allPlayersMatchForms);
                footballStatisticTable.LooseRatio = _uow.FootballStats.GetLooseRatioStat(players, allPlayersMatchForms);

                return footballStatisticTable;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });

        }        

        private async Task<List<MatchResultByPlayer>> GetPlayersMatchFormsAsync(int matchGroupId, IEnumerable<Player> players)
        {
            var list = new List<MatchResultByPlayer>();

            foreach (var player in players)
            {
                var playerStatsResult = await _uow.FootballStats.GetAllByMatchGroupIdAndPlayerIdAsync(matchGroupId, player.Id);
                var playerStats = playerStatsResult;
                var playerStatResponse = Mapper.Map<IList<FootballStatResponse>>(playerStats);
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

        private async Task CheckValuesAsync(FootballStat footballStat, bool update = false, int? id = null)
        {
            var matchPlayerAndTeamUniqueResult =
                await _uow.FootballStats.GetByMatchIdTeamIdAndPlayerId(footballStat.MatchId, footballStat.TeamId, footballStat.PlayerId);

            if (update)
                matchPlayerAndTeamUniqueResult.CheckUniqueValueForUpdate((int)id, AppConstants.MatchIdAndTeamIdAndPlayerId);
            else
                matchPlayerAndTeamUniqueResult.CheckUniqueValue(AppConstants.MatchIdAndTeamIdAndPlayerId);
        }        
    }
}