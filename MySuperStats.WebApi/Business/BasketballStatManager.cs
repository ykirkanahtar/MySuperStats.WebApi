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
                    await _uow.BasketballStats.GetByMatchIdTeamIdAndPlayerId(result.MatchId, result.TeamId, result.PlayerId);

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
                    await _uow.BasketballStats.GetByMatchIdTeamIdAndPlayerId(result.MatchId, result.TeamId, result.PlayerId);

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

        public Task<ICustomList<BasketballStat>> GetAllByMatchIdAsync(int matchId)
        {
            return CommonOperationAsync(async () => await _uow.BasketballStats.GetAllByMatchIdAsync(matchId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<ICustomList<BasketballStat>> GetAllByPlayerIdAsync(int playerId)
        {
            return CommonOperationAsync(async () => await _uow.BasketballStats.GetAllByPlayerIdAsync(playerId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<ICustomList<BasketballStat>> GetAllAsync()
        {
            return CommonOperationAsync(async () => await _uow.BasketballStats.GetAllAsync(), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);

        }

        public Task<BasketballStatisticTable> GetTopStats()
        {
            return CommonOperation(async () =>
            {
                var playersResult = await _uow.Players.GetAllAsync();
                var players = playersResult.ResultList;

                var statsResult = await _uow.BasketballStats.GetAllAsync();
                var stats = statsResult.ResultList;

                var basketballStatisticTable = new BasketballStatisticTable
                {
                    Points = _uow.BasketballStats.GetTopPointsStat(players, stats),
                    PointPerMatch = _uow.BasketballStats.GetTopPointsPerMatchStat(players, stats),
                    OnePoint = _uow.BasketballStats.GetTopOnePointStat(players, stats),
                    OnePointPerMatch = _uow.BasketballStats.GetTopOnePointPerMatchStat(players, stats),
                    OnePointRatio = _uow.BasketballStats.GetOnePointRatioStat(players, stats),
                    TwoPoint = _uow.BasketballStats.GetTwoPointStat(players, stats),
                    TwoPointPerMatch = _uow.BasketballStats.GetTwoPointPerMatchStat(players, stats),
                    TwoPointRatio = _uow.BasketballStats.GetTwoPointRatioStat(players, stats),
                    Rebounds = _uow.BasketballStats.GetReboundStat(players, stats),
                    ReboundPerMatch = _uow.BasketballStats.GetReboundPerMatchStat(players, stats),
                    Steals = _uow.BasketballStats.GetStealStat(players, stats),
                    StealsPerMatch = _uow.BasketballStats.GetStealPerMatchStat(players, stats),
                    Turnovers = _uow.BasketballStats.GetTurnoverStat(players, stats),
                    TurnoversPerMatch = _uow.BasketballStats.GetTurnoverPerMatchStat(players, stats),
                    Assist = _uow.BasketballStats.GetAssistStat(players, stats),
                    AssistPerMatch = _uow.BasketballStats.GetAssistPerMatchStat(players, stats),
                    Interrupts = _uow.BasketballStats.GetInterruptStat(players, stats),
                    InterruptPerMatch = _uow.BasketballStats.GetInterruptPerMatchStat(players, stats)
                };

                var allPlayersMatchForms = await GetPlayersMatchFormsAsync(players);

                basketballStatisticTable.Wins = _uow.BasketballStats.GetWinsStat(players, allPlayersMatchForms);
                basketballStatisticTable.WinRatio = _uow.BasketballStats.GetWinRatioStat(players, allPlayersMatchForms);
                basketballStatisticTable.Looses = _uow.BasketballStats.GetLoosesStat(players, allPlayersMatchForms);
                basketballStatisticTable.LooseRatio = _uow.BasketballStats.GetLooseRatioStat(players, allPlayersMatchForms);

                return basketballStatisticTable;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });

        }

        private async Task<List<MatchResultByPlayer>> GetPlayersMatchFormsAsync(IEnumerable<Player> players)
        {
            var list = new List<MatchResultByPlayer>();

            foreach (var player in players)
            {
                var playerStatsResult = await _uow.BasketballStats.GetAllByPlayerIdAsync(player.Id);
                var playerStats = playerStatsResult.ResultList;
                var playerStatResponse = Mapper.Map<IList<BasketballStatResponse>>(playerStats);
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
