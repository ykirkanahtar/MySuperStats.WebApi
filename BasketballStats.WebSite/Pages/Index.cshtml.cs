using BasketballStats.WebSite.Business;
using BasketballStats.WebSite.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballStats.WebSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMatch _match;
        private readonly IStat _stat;
        public List<MatchDetail> Matches { get; set; }

        public IndexModel(IMatch match, IStat stat)
        {
            _match = match;
            _stat = stat;
            Matches = new List<MatchDetail>();
        }

        public async Task OnGet()
        {
            var matches = await _match.GetAll();

            foreach (var match in matches)
            {
                var matchDetail = new MatchDetail();
                var matchStats = await _stat.GetStatsByMatchId(match.Id);

                matchDetail.MatchInfo = matchStats.Select(p => p.Match).Distinct().FirstOrDefault();

                matchDetail.HomeTeamScore = _stat.GetScoreByStatsAndTeamId(matchStats, matchDetail.MatchInfo.HomeTeamId);
                matchDetail.AwayTeamScore = _stat.GetScoreByStatsAndTeamId(matchStats, matchDetail.MatchInfo.AwayTeamId);

                Matches.Add(matchDetail);
            }
            var sortedMatches = Matches.OrderBy(p => p.MatchInfo.MatchDate).ThenBy(p => p.MatchInfo.Order).ToList();
            Matches = sortedMatches;
        }

    }
}
