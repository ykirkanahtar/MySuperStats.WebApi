using System.Threading.Tasks;
using BasketballStats.Contracts.Requests;
using BasketballStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;

namespace BasketballStats.WebApi.Business
{
    public interface IPlayerManager : IBusinessManager<Player, PlayerRequest, int>
    , IBusinessManagerUpdate<Player, PlayerRequest, int>
    {
        Task<ICustomList<Player>> GetAllAsync();
    }
}