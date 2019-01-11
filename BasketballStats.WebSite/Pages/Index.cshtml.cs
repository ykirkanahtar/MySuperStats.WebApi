using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Business;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballStats.WebSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMatch _match;
        private readonly IStat _stat;
        public List<MatchForMainScreen> Matches { get; set; }

        public IndexModel(IMatch match, IStat stat)
        {
            _match = match;
            _stat = stat;
            Matches = new List<MatchForMainScreen>();
        }

        public async Task OnGet()
        {
            Matches = await _match.GetAllForMainScreen();
        }
    }
}
