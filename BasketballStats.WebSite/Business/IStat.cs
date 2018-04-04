using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballStats.WebSite.Business
{
    public interface IStat
    {
        Task<List<StatResponse>> GetStatsByMatchId(int matchId);

        Task<List<StatResponse>> GetStatsByPlayerId(int playerId);

        Task<List<StatResponse>> GetAll();

        StatResponse AddPlayerStatToTeamStats(StatResponse teamStats, StatResponse playerStat);

        StatResponse GetPlayerStatByMatchIdAndTeamId(int playerId, int teamId, IList<StatResponse> matchStats);

        StatResponse GetTotalStats(IList<StatResponse> playerStats);

        StatResponse GetPerMatchStats(StatResponse totalStats, List<StatResponse> playerStats);

        IList<MatchScore> GetMatchFormsByPlayerId(IList<StatResponse> allMatchStats, int playerId);

        decimal GetScoreByStatsAndTeamId(IList<StatResponse> matchStats, int teamId);

        int GetTotalWinsByMatchForms(IList<MatchScore> matchForms);

        int GetTotalLoosesByMatchForms(IList<MatchScore> matchForms);

        int GetWinRatioByMatchForms(IList<MatchScore> matchForms);

        int GetLooseRatioByMatchForms(IList<MatchScore> matchForms);

        decimal GetPointRatio(decimal point, decimal missing);

        decimal GetTotalPoint(decimal onePoint, decimal twoPoint);

        decimal GetPerMatchTotalPoint(decimal totalPoint, int matchCount);

        int GetMatchCount(IList<StatResponse> stats);

        int GetMatchCountByTwoPointStat(IList<StatResponse> stats);

    }
}
