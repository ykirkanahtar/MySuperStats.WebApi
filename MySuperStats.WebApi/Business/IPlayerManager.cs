using System.Threading.Tasks;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Models;
using CustomFramework.WebApiUtils.Business;
using System.Collections.Generic;

namespace MySuperStats.WebApi.Business
{
    public interface IPlayerManager : IBusinessManager<Player, PlayerRequest, int>
    , IBusinessManagerUpdate<Player, PlayerRequest, int>
    {
        Task<Player> GetWithStats(int id);
        Task<IList<Player>> GetAllAsync();
    }
}