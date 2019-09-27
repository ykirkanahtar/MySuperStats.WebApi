namespace MySuperStats.Contracts.Responses
{
    public class WinLooseTable
    {
        public WinLooseTable(decimal win, decimal loose, decimal winRatio, decimal looseRatio)
        {
            Win = win;
            Loose = loose;
            WinRatio = winRatio;
            LooseRatio = looseRatio;
        }

        public decimal Win { get; set; }
        public decimal Loose { get; set; }
        public decimal WinRatio { get; set; }
        public decimal LooseRatio { get; set; }
    }
}