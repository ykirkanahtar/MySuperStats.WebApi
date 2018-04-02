namespace BasketballStats.WebApi.Data.Utils
{
    public class SkipTake
    {
        public SkipTake(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public int Skip { get; }
        public int Take { get; }
    }
}
