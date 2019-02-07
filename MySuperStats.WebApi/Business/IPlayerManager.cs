using System.Threading.Tasks;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;

namespace MySuperStats.WebApi.Business
{
    public interface IPlayerManager : IBusinessManager<Player, PlayerRequest, int>
    , IBusinessManagerUpdate<Player, PlayerRequest, int>
    {
        Task<Player> GetWithStats(int id);
        Task<ICustomList<Player>> GetAllAsync();
    }
}