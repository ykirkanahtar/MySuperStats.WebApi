using System.Threading.Tasks;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;
using System.Collections.Generic;

namespace MySuperStats.WebApi.Business
{
    public interface IBasketballStatManager : IBusinessManager<BasketballStat, BasketballStatRequest, int>
    , IBusinessManagerUpdate<BasketballStat, BasketballStatRequest, int>
    {
        Task<IList<BasketballStat>> GetAllByMatchIdAsync(int matchId);
        Task<IList<BasketballStat>> GetAllByUserIdAsync(int userId);
        Task<IList<BasketballStat>> GetAllAsync();
        Task<BasketballStatisticTable> GetTopStats();
    }
}