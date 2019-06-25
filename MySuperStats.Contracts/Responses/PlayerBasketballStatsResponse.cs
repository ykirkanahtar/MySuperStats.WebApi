namespace MySuperStats.Contracts.Responses
{
    public class PlayerBasketballStatsResponse
    {
        public UserResponse Player { get; set; }
        public BasketballStatResponse BasketballStat { get; set; }
    }

}
