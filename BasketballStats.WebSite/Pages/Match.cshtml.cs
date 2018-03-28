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
                var matchResponses = JsonConvert.DeserializeObject<List<MatchResponse>>(response.Result.ToString());
                foreach (var matchResponse in matchResponses)
                {
                    var customMatchModel = new CustomMatchModel
                    {
                        Match = matchResponse,
                        HomeTeamScore = (from p in matchResponse.Stats
                            where p.TeamId == matchResponse.HomeTeamId
                            select p.OnePoint + p.TwoPoint).Sum(),
                        AwayTeamScore = (from p in matchResponse.Stats
                            where p.TeamId == matchResponse.AwayTeamId
                            select p.OnePoint + p.TwoPoint).Sum()
                    };
                    
                    Matches.Add(customMatchModel);
                }
            }
        }
    }

    public class CustomMatchModel
    {
        public MatchResponse Match { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
    }
}
