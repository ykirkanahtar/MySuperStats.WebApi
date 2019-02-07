namespace MySuperStats.Contracts.Responses
{
    public class StatisticDetail
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int GameCount { get; set; }
        public decimal Value { get; set; }
    }
}