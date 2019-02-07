using System.Threading.Tasks;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;

namespace MySuperStats.WebApi.Business
{
    public interface IBasketballStatManager : IBusinessManager<BasketballStat, BasketballStatRequest, int>
    , IBusinessManagerUpdate<BasketballStat, BasketballStatRequest, int>
    {
        Task<ICustomList<BasketballStat>> GetAllByMatchIdAsync(int matchId);
        Task<ICustomList<BasketballStat>> GetAllByPlayerIdAsync(int playerId);
        Task<ICustomList<BasketballStat>> GetAllAsync();
        Task<BasketballStatisticTable> GetTopStats();
    }
}