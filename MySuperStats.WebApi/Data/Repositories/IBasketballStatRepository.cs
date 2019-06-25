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
    public interface IBasketballStatRepository : IRepository<BasketballStat, int>
    {
        Task<BasketballStat> GetByMatchIdTeamIdAndUserId(int matchId, int teamId, int userId);
        Task<decimal> GetTeamScoreByMatchIdAndTeamId(int matchId, int teamId);
        Task<IList<BasketballStat>> GetAllByMatchIdAsync(int matchId);
        Task<IList<BasketballStat>> GetAllByUserIdAsync(int userId);
        Task<IList<BasketballStat>> GetAllAsync();
        List<StatisticDetail> GetTopPointsStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetTopPointsPerMatchStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetTopOnePointStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetTopOnePointPerMatchStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetOnePointRatioStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetTwoPointStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetTwoPointPerMatchStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetTwoPointRatioStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetReboundStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetReboundPerMatchStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetStealStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetStealPerMatchStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetTurnoverStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetTurnoverPerMatchStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetAssistStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetAssistPerMatchStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetInterruptStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetInterruptPerMatchStat(IList<User> users, IList<BasketballStat> stats);
        List<StatisticDetail> GetWinsStat(IList<User> users, List<MatchResultByUser> matchResultByUsers);
        List<StatisticDetail> GetWinRatioStat(IList<User> users, List<MatchResultByUser> matchResultByUsers);
        List<StatisticDetail> GetLoosesStat(IList<User> users, List<MatchResultByUser> matchResultByUsers);
        List<StatisticDetail> GetLooseRatioStat(IList<User> users, List<MatchResultByUser> matchResultByUsers);
    }
}