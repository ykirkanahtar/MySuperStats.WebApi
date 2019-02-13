using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Business
{
    public interface IMatchGroupPlayerManager : IBusinessManager<MatchGroupPlayer, MatchGroupPlayerRequest, int>
    {
        Task<ICustomList<MatchGroup>> GetMatchGroupsByPlayerIdAsync(int playerId);
        Task<ICustomList<Player>> GetPlayersByMatchGroupIdAsync(int matchGroupId);
    }
}