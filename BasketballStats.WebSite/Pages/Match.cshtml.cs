using BasketballStats.WebSite.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BasketballStats.WebSite.ResponseModels;

namespace BasketballStats.WebSite.Pages
{
    public class MatchModel : PageModel
    {
        private readonly WebApiConnector _webApiConnector;
        public List<CustomMatchModel> Matches;

        public MatchModel(WebApiConnector webApiConnector)
        {
            _webApiConnector = webApiConnector;
            Matches = new List<CustomMatchModel>();
        }

        public async Task OnGet()
        {
            var response = await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/match/getall");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var matches = JsonConvert.DeserializeObject<List<MatchResponse>>(response.Result.ToString());
                foreach (var match in matches)
                {
                    var statResponse = await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/stat/getall/matchid/{match.Id}");
                    IList<StatResponse> stats = new List<StatResponse>();

                    if (statResponse.StatusCode == HttpStatusCode.OK)
                    {
                        stats = JsonConvert.DeserializeObject<List<StatResponse>>(statResponse.Result.ToString());
                    }

                    var customMatchModel = new CustomMatchModel
                    {
                        Match = match,
                        HomeTeamScore = (from p in stats
                                         where p.TeamId == match.HomeTeamId
                                         select p.OnePoint + p.TwoPoint).Sum(),
                        AwayTeamScore = (from p in stats
                                         where p.TeamId == match.AwayTeamId
                                         select p.OnePoint + p.TwoPoint).Sum()
                    };
                    Matches.Add(customMatchModel);
                }
                var sortedMatches = Matches.OrderBy(p => p.Match.MatchDate).ThenBy(p => p.Match.Order).ToList();
                Matches = sortedMatches;
            }
        }
    }

    public class CustomMatchModel
    {
        public MatchResponse Match { get; set; }
        public decimal HomeTeamScore { get; set; }
        public decimal AwayTeamScore { get; set; }
    }
}
