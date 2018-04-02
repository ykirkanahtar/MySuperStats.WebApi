using BasketballStats.WebSite.Models;
using BasketballStats.WebSite.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BasketballStats.Contracts.Responses;

namespace BasketballStats.WebSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebApiConnector _webApiConnector;
        public List<CustomMatchModel> Matches { get; set; }

        public IndexModel(WebApiConnector webApiConnector)
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
                    var customMatchModel = new CustomMatchModel();
                    var matchStatResponse = await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/stat/getall/matchid/{match.Id}");
                    if (matchStatResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var matchStats = JsonConvert.DeserializeObject<List<StatResponse>>(matchStatResponse.Result.ToString());
                        customMatchModel.Match = matchStats.Select(p => p.Match).Distinct().FirstOrDefault();

                        customMatchModel.HomeTeamScore = (from p in matchStats
                            where p.TeamId == customMatchModel.Match.HomeTeamId
                            select p.OnePoint + (p.TwoPoint * 2)).Sum();
                        customMatchModel.AwayTeamScore = (from p in matchStats
                            where p.TeamId == customMatchModel.Match.AwayTeamId
                            select p.OnePoint + (p.TwoPoint * 2)).Sum();
                    }
                    Matches.Add(customMatchModel);
                }
                var sortedMatches = Matches.OrderBy(p => p.Match.MatchDate).ThenBy(p => p.Match.Order).ToList();
                Matches = sortedMatches;
            }
        }

    }
}
