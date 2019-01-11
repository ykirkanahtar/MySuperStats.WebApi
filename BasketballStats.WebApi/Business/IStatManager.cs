using System.Threading.Tasks;
using BasketballStats.Contracts.Requests;
using BasketballStats.Contracts.Responses;
using BasketballStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;

namespace BasketballStats.WebApi.Business
{
    public interface IStatManager : IBusinessManager<Stat, StatRequest, int>
    , IBusinessManagerUpdate<Stat, StatRequest, int>
    {
        Task<ICustomList<Stat>> GetAllByMatchIdAsync(int matchId);
        Task<ICustomList<Stat>> GetAllByPlayerIdAsync(int playerId);
        Task<ICustomList<Stat>> GetAllAsync();
        Task<StatisticTable> GetTopStats();
    }
}