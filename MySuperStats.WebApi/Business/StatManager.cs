using System.Collections.Generic;
using AutoMapper;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Constants;
using MySuperStats.WebApi.Data;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Responses;
using MySuperStats.Contracts.Utils;
using CustomFramework.WebApiUtils.Contracts;

namespace MySuperStats.WebApi.Business
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

                await UpdateMatchScores(request.MatchId);

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        private Task UpdateMatchScores(int matchId)
        {
            return CommonOperationAsync(async () =>
            {
                var match = _uow.Matches.GetById(matchId);
                match.HomeTeamScore = await _uow.Stats.GetTeamScoreByMatchIdAndTeamId(matchId, match.HomeTeamId);
                match.AwayTeamScore = await _uow.Stats.GetTeamScoreByMatchIdAndTeamId(matchId, match.AwayTeamId);
                _uow.Matches.Update(match, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

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

                await UpdateMatchScores(request.MatchId);

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

                await UpdateMatchScores(result.MatchId);

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

        public Task<StatisticTable> GetTopStats()
        {
            return CommonOperation(async () =>
            {
                var playersResult = await _uow.Players.GetAllAsync();
                var players = playersResult.ResultList;

                var statsResult = await _uow.Stats.GetAllAsync();
                var stats = statsResult.ResultList;

                var statisticTable = new StatisticTable
                {
                    Points = _uow.Stats.GetTopPointsStat(players, stats),
                    PointPerMatch = _uow.Stats.GetTopPointsPerMatchStat(players, stats),
                    OnePoint = _uow.Stats.GetTopOnePointStat(players, stats),
                    OnePointPerMatch = _uow.Stats.GetTopOnePointPerMatchStat(players, stats),
                    OnePointRatio = _uow.Stats.GetOnePointRatioStat(players, stats),
                    TwoPoint = _uow.Stats.GetTwoPointStat(players, stats),
                    TwoPointPerMatch = _uow.Stats.GetTwoPointPerMatchStat(players, stats),
                    TwoPointRatio = _uow.Stats.GetTwoPointRatioStat(players, stats),
                    Rebounds = _uow.Stats.GetReboundStat(players, stats),
                    ReboundPerMatch = _uow.Stats.GetReboundPerMatchStat(players, stats),
                    Steals = _uow.Stats.GetStealStat(players, stats),
                    StealsPerMatch = _uow.Stats.GetStealPerMatchStat(players, stats),
                    Turnovers = _uow.Stats.GetTurnoverStat(players, stats),
                    TurnoversPerMatch = _uow.Stats.GetTurnoverPerMatchStat(players, stats),
                    Assist = _uow.Stats.GetAssistStat(players, stats),
                    AssistPerMatch = _uow.Stats.GetAssistPerMatchStat(players, stats),
                    Interrupts = _uow.Stats.GetInterruptStat(players, stats),
                    InterruptPerMatch = _uow.Stats.GetInterruptPerMatchStat(players, stats)
                };

                var allPlayersMatchForms = await GetPlayersMatchFormsAsync(players);

                statisticTable.Wins = _uow.Stats.GetWinsStat(players, allPlayersMatchForms);
                statisticTable.WinRatio = _uow.Stats.GetWinRatioStat(players, allPlayersMatchForms);
                statisticTable.Looses = _uow.Stats.GetLoosesStat(players, allPlayersMatchForms);
                statisticTable.LooseRatio = _uow.Stats.GetLooseRatioStat(players, allPlayersMatchForms);

                return statisticTable;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });

        }

        private async Task<List<MatchResultByPlayer>> GetPlayersMatchFormsAsync(IEnumerable<Player> players)
        {
            var list = new List<MatchResultByPlayer>();

            foreach (var player in players)
            {
                var playerStatsResult = await _uow.Stats.GetAllByPlayerIdAsync(player.Id);
                var playerStats = playerStatsResult.ResultList;
                var playerStatResponse = Mapper.Map<IList<StatResponse>>(playerStats);
                var matchResults = playerStatResponse.GetMatchResultByMatchAndPlayerId();
                var matchResutsStrings = new List<string>();
                foreach (var matchResult in matchResults)
                {
                    matchResutsStrings.Add(matchResult.ToString().Substring(0, 1));
                    list.Add(new MatchResultByPlayer(player, matchResult));
                }
                //matchForms.Add(player.Id, matchResutsStrings);
            }

            return list;
        }
    }
}
