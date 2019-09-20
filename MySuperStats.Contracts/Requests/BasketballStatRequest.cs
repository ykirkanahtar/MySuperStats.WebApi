using System.ComponentModel.DataAnnotations;

namespace MySuperStats.Contracts.Requests
{
    public class BasketballStatRequest : BaseBasketballStatRequest
    {

        [Range(1, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        public int MatchId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        public int TeamId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        public int UserId { get; set; }

        public virtual MatchRequest Match { get; set; }
        public virtual TeamRequest Team { get; set; }
    }
}
