using BasketballStats.WebSite.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Models;
using BasketballStats.WebSite.Business;

namespace BasketballStats.WebSite.Pages
{
    public class MatchDetailModel : PageModel
    {
        private readonly IStat _stat;
        private readonly ITeam _team;

        public MatchDetail MatchDetailInfo { get; set; }

        public MatchDetailModel(IStat stat, ITeam team)
        {
            _stat = stat;
            _team = team;
            MatchDetailInfo = new MatchDetail();
        }

        public async Task OnGet(int id)
        {
            var matchId = id; //TODO routing konusunu araştırınca burayı düzelt

            var matchStats = await _stat.GetStatsByMatchId(matchId);

            var match = matchStats.Select(p => p.Match).Distinct().First();
            MatchDetailInfo.MatchInfo = match;
            MatchDetailInfo.HomeTeam = _team.GetTeamDetailByTeamResponse(_stat, match.HomeTeam, matchStats);
            MatchDetailInfo.AwayTeam = _team.GetTeamDetailByTeamResponse(_stat, match.AwayTeam, matchStats);
        }

    }
}
