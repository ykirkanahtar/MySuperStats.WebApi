using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BasketballStats.WebSite.ResponseModels;
using BasketballStats.WebSite.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BasketballStats.WebSite.Pages
{
    public class StatModel : PageModel
    {
        private readonly WebApiConnector _webApiConnector;
        public List<CustomStatModel> Stats;

        public StatModel(WebApiConnector webApiConnector)
        {
            _webApiConnector = webApiConnector;
            Stats = new List<CustomStatModel>();
        }

        public async Task OnGet()
        {
            var matchId = 1;
            var response = await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/stat/getallplayer/matchid/{matchId}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var playerResponses = JsonConvert.DeserializeObject<List<PlayerResponse>>(response.Result.ToString());
                foreach (var playerResponse in playerResponses)
                {
                    var customStatModel = new CustomStatModel { Player = playerResponse };

                    var statResponse = await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/stat/get/matchid/{matchId}/playerid/{playerResponse.Id}");
                    if (statResponse.StatusCode == HttpStatusCode.OK)
                    {
                        customStatModel.Stat = JsonConvert.DeserializeObject<StatResponse>(statResponse.Result.ToString());
                    }
                    Stats.Add(customStatModel);
                }
            }
        }
    }

    public class CustomStatModel
    {
        public PlayerResponse Player { get; set; }
        public StatResponse Stat { get; set; }
    }

}
