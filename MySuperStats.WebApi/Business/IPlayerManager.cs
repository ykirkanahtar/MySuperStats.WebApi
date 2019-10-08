using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Business;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Business
{
    public interface IPlayerManager : IBusinessManagerUpdate<Player, UpdatePlayerRequest, int>
    {
        Task<Player> CreateAsync(CreatePlayerRequest request, int? userId = null);//Misafir oyuncu ise UserId null olacak
        Task DeleteAsync(int id);
        Task<Player> GetByIdAsync(int id);
        Task<User> GetUserByIdAsync(int id);
        Task<UserDetailWithBasketballStat> GetByIdWithBasketballStatsAsync(int id);
        Task<IList<Player>> GetAllByMatchGroupIdAsync(int matchGroupId);
    }
}