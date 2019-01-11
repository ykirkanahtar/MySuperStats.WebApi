using BasketballStats.Contracts.Enums;
using BasketballStats.Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballStats.WebSite.Business
{
    public interface IStat
    {
        Task<StatisticTable> GetTopStats();
    }
}
