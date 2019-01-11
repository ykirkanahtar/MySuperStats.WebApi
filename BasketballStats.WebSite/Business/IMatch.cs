using BasketballStats.Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballStats.WebSite.Business
{
    public interface IMatch
    {
        Task<List<MatchForMainScreen>> GetAllForMainScreen();
        Task<MatchDetailStatsResponse> GetMatchDetailStats(int matchId);
    }
}
