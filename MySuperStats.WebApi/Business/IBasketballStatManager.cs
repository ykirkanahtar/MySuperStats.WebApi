using System.Threading.Tasks;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Models;
using CustomFramework.WebApiUtils.Business;
using System.Collections.Generic;

namespace MySuperStats.WebApi.Business
{
    public interface IBasketballStatManager : IBusinessManager<BasketballStat, BasketballStatRequest, int>
    , IBusinessManagerUpdate<BasketballStat, BasketballStatRequest, int>
    {
        Task<int> CreateMultiStats(CreateMatchRequestWithMultiBasketballStats request);
        Task<IList<BasketballStat>> GetAllByMatchIdAsync(int matchId);
        Task<IList<BasketballStat>> GetAllByMatchGroupIdAndPlayerIdAsync(int matchGroupId, int playerId);
        Task<IList<BasketballStat>> GetAllByMatchGroupIdAsync(int matchGroupId);
        Task<BasketballStatisticTable> GetTopStats(int matchGroupId);
    }
}