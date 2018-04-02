using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Utils;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BasketballStats.WebSite.Models
{
    public class CustomMatchModel
    {
        public MatchResponse Match { get; set; }
        public decimal HomeTeamScore { get; set; }
        public decimal AwayTeamScore { get; set; }
    }
}
