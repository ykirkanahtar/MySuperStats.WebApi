using System.Collections.Generic;
using System.Linq;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using System.Threading.Tasks;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Responses;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IStatRepository : IRepository<Stat, int>
    {
        Task<Stat> GetByMatchIdTeamIdAndPlayerId(int matchId, int teamId, int playerId);
        Task<decimal> GetTeamScoreByMatchIdAndTeamId(int matchId, int teamId);
        Task<ICustomList<Stat>> GetAllByMatchIdAsync(int matchId);
        Task<ICustomList<Stat>> GetAllByPlayerIdAsync(int playerId);
        Task<ICustomList<Stat>> GetAllAsync();
        List<StatisticDetail> GetTopPointsStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetTopPointsPerMatchStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetTopOnePointStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetTopOnePointPerMatchStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetOnePointRatioStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetTwoPointStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetTwoPointPerMatchStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetTwoPointRatioStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetReboundStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetReboundPerMatchStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetStealStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetStealPerMatchStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetTurnoverStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetTurnoverPerMatchStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetAssistStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetAssistPerMatchStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetInterruptStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetInterruptPerMatchStat(IList<Player> players, IList<Stat> stats);
        List<StatisticDetail> GetWinsStat(IList<Player> players, List<MatchResultByPlayer> matchResultByPlayers);
        List<StatisticDetail> GetWinRatioStat(IList<Player> players, List<MatchResultByPlayer> matchResultByPlayers);
        List<StatisticDetail> GetLoosesStat(IList<Player> players, List<MatchResultByPlayer> matchResultByPlayers);
        List<StatisticDetail> GetLooseRatioStat(IList<Player> players, List<MatchResultByPlayer> matchResultByPlayers);
    }
}