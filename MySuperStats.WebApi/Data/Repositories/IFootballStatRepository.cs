using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.BaseWebApi.Data.Repositories;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IFootballStatRepository : IRepository<FootballStat, int>
    {
        Task<FootballStat> GetByMatchIdTeamIdAndPlayerId(int matchId, int teamId, int playerId);
        Task<decimal> GetTeamScoreByMatchIdAndTeamId(int matchId, int teamId);
        Task<IList<FootballStat>> GetAllByMatchIdAsync(int matchId);
        Task<IList<FootballStat>> GetAllByMatchGroupIdAndPlayerIdAsync(int matchGroupId, int playerId);
        Task<IList<FootballStat>> GetAllByMatchGroupIdAsync(int matchGroupId);
        List<StatisticDetail> GetTopGoalsStat(IList<Player> players, IList<FootballStat> stats);
        List<StatisticDetail> GetTopGoalsPerMatchStat(IList<Player> players, IList<FootballStat> stats);
        List<StatisticDetail> GetOwnGoalStat(IList<Player> players, IList<FootballStat> stats);
        List<StatisticDetail> GetOwnGoalPerMatchStat(IList<Player> players, IList<FootballStat> stats);
        List<StatisticDetail> GetPenaltyScoreStat(IList<Player> players, IList<FootballStat> stats);
        List<StatisticDetail> GetPenaltyScorePerMatchStat(IList<Player> players, IList<FootballStat> stats);
        List<StatisticDetail> GetMissedPenaltyStat(IList<Player> players, IList<FootballStat> stats);
        List<StatisticDetail> GetMissedPenaltyPerMatchStat(IList<Player> players, IList<FootballStat> stats);
        List<StatisticDetail> GetAssistStat(IList<Player> players, IList<FootballStat> stats);
        List<StatisticDetail> GetAssistPerMatchStat(IList<Player> players, IList<FootballStat> stats);
        List<StatisticDetail> GetSaveGoalStat(IList<Player> players, IList<FootballStat> stats);
        List<StatisticDetail> GetSaveGoalPerMatchStat(IList<Player> players, IList<FootballStat> stats);
        List<StatisticDetail> GetConcedeGoalStat(IList<Player> players, IList<FootballStat> stats);
        List<StatisticDetail> GetConcedeGoalPerMatchStat(IList<Player> players, IList<FootballStat> stats);
        List<StatisticDetail> GetWinsStat(IList<Player> players, List<MatchResultByPlayer> matchResultByPlayers);
        List<StatisticDetail> GetWinRatioStat(IList<Player> players, List<MatchResultByPlayer> matchResultByPlayers);
        List<StatisticDetail> GetLoosesStat(IList<Player> players, List<MatchResultByPlayer> matchResultByPlayers);
        List<StatisticDetail> GetLooseRatioStat(IList<Player> players, List<MatchResultByPlayer> matchResultByPlayers);


    }
}