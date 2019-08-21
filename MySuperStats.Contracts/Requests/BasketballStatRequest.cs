namespace MySuperStats.Contracts.Requests
{
    public class BasketballStatRequest : BaseBasketballStatRequest
    {

        public int MatchId { get; set; }

        public int TeamId { get; set; }
        public int UserId { get; set; }

        public virtual MatchRequest Match { get; set; }
        public virtual TeamRequest Team { get; set; }
    }
}
