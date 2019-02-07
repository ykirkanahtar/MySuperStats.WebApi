using System.Threading.Tasks;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;

namespace MySuperStats.WebApi.Business
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