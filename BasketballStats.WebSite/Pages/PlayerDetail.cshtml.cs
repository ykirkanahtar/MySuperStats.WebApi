using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Business;

namespace BasketballStats.WebSite.Pages
{
    public class PlayerDetailModel : PageModel
    {
        private readonly IPlayer _player;

        public PlayerDetailResponse PlayerDetailInfo { get; set; }

        public PlayerDetailModel(IPlayer player)
        {
            _player = player;
            PlayerDetailInfo = new PlayerDetailResponse();
        }

        public async Task OnGet(int id)
        {
            PlayerDetailInfo = await _player.GetWithStatsById(id);
        }
    }
}
