namespace BasketballStats.Contracts.Responses
{
    public class WinLooseTable
    {
        public decimal Win { get; set; }
        public decimal Loose { get; set; }
        public decimal WinRatio { get; set; }
        public decimal LooseRatio { get; set; }
    }
}