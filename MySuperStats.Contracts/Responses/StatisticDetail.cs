namespace MySuperStats.Contracts.Responses
{
    public class StatisticDetail
    {
        public int UserId { get; set; }
        public string FirstNameLastName { get; set; }
        public int GameCount { get; set; }
        public decimal Value { get; set; }
    }
}