using System.Collections.Generic;

namespace BasketballStats.WebApi.Helper
{
    public class CustomEntityList<T> where T : class
    {
        public List<T> EntityList { get; set; }
        public int Count { get; set; }
    }
}