using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BasketballStats.WebSite.Pages
{
    public class PlayerModel : PageModel
    {
        private readonly WebApiConnector _webApiConnector;
        public List<PlayerResponse> PlayerList { get; set; }

        public PlayerModel(WebApiConnector webApiConnector)
        {
            _webApiConnector = webApiConnector;
            PlayerList = new List<PlayerResponse>();
        }

        public async Task OnGet()
        {
            var playerResponse =
                await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/player/getall");
            if (playerResponse.StatusCode == HttpStatusCode.OK)
            {
                var players = JsonConvert.DeserializeObject<List<PlayerResponse>>(playerResponse.Result.ToString());
                PlayerList = players.OrderBy(p => p.Name).ToList();
            }
        }
    }
}
