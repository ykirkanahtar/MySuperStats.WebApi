using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Business;
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
        private readonly IPlayer _player;
        public List<PlayerResponse> PlayerList { get; set; }

        public PlayerModel(IPlayer player)
        {
            _player = player;
            PlayerList = new List<PlayerResponse>();
        }

        public async Task OnGet()
        {
            var players = await _player.GetAll();
            PlayerList = players.OrderBy(p => p.Name).ToList();
        }
    }
}
