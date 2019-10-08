using System.Collections.Generic;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.Repositories;
using System.Threading.Tasks;
using MySuperStats.Contracts.Responses;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IBasketballStatRepository : IRepository<BasketballStat, int>
    {
        Task<BasketballStat> GetByMatchIdTeamIdAndPlayerId(int matchId, int teamId, int playerId);
        Task<decimal> GetTeamScoreByMatchIdAndTeamId(int matchId, int teamId);
        Task<IList<BasketballStat>> GetAllByMatchIdAsync(int matchId);
        Task<IList<BasketballStat>> GetAllByMatchGroupIdAndPlayerIdAsync(int matchGroupId, int playerId);
        Task<IList<BasketballStat>> GetAllByMatchGroupIdAsync(int matchGroupId);
        List<StatisticDetail> GetTopPointsStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetTopPointsPerMatchStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetTopOnePointStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetTopOnePointPerMatchStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetOnePointRatioStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetTwoPointStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetTwoPointPerMatchStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetTwoPointRatioStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetReboundStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetReboundPerMatchStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetStealStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetStealPerMatchStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetTurnoverStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetTurnoverPerMatchStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetAssistStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetAssistPerMatchStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetInterruptStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetInterruptPerMatchStat(IList<Player> players, IList<BasketballStat> stats);
        List<StatisticDetail> GetWinsStat(IList<Player> players, List<MatchResultByPlayer> matchResultByPlayers);
        List<StatisticDetail> GetWinRatioStat(IList<Player> players, List<MatchResultByPlayer> matchResultByPlayers);
        List<StatisticDetail> GetLoosesStat(IList<Player> players, List<MatchResultByPlayer> matchResultByPlayers);
        List<StatisticDetail> GetLooseRatioStat(IList<Player> players, List<MatchResultByPlayer> matchResultByPlayers);
    }
}