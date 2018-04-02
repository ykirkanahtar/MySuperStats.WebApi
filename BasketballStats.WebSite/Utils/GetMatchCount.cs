using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballStats.Contracts.Responses;

namespace BasketballStats.WebSite.Utils
{
    public class GetMatchCount
    {
        public static int All(IList<StatResponse> stats)
        {
            return stats.Select(p => p.MatchId).Distinct().Count();
        }

        public static int GetByTwoPointStat(IList<StatResponse> stats)
        {
            return stats.Where(p => p.Match.MatchDate >= new DateTime(2018, 3, 29))
                .Select(p => p.MatchId).Distinct().Count();
        }
    }
}
