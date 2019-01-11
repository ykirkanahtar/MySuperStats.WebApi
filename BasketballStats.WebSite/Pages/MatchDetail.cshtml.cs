using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Business;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BasketballStats.WebSite.Pages
{
    public class MatchDetailModel : PageModel
    {
        private readonly IMatch _match;

        public MatchDetailStatsResponse MatchDetailStats { get; set; }

        public MatchDetailModel(IMatch match)
        {
            _match = match;
            MatchDetailStats = new MatchDetailStatsResponse();
        }

        public async Task OnGet(int id)
        {
            MatchDetailStats = await _match.GetMatchDetailStats(id);
        }
    }
}
