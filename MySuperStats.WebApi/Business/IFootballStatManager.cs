using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Business
{
    public interface IFootballStatManager : IBusinessManager<FootballStat, FootballStatRequest, int>
    , IBusinessManagerUpdate<FootballStat, FootballStatRequest, int>
    {
        Task<ICustomList<FootballStat>> GetAllByMatchIdAsync(int matchId);
        Task<ICustomList<FootballStat>> GetAllByPlayerIdAsync(int playerId);
        Task<ICustomList<FootballStat>> GetAllAsync();
    }
}