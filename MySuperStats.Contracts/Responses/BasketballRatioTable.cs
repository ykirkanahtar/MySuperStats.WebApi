namespace MySuperStats.Contracts.Responses
{
    public class BasketballRatioTable
    {
        public BasketballRatioTable(decimal onePointRatio, decimal twoPointRatio)
        {
            OnePointRatio = onePointRatio;
            TwoPointRatio = twoPointRatio;
        }

        public decimal OnePointRatio { get; set; }
        public decimal TwoPointRatio { get; set; }
    }
} 