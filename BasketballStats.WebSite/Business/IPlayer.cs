using BasketballStats.Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballStats.WebSite.Business
{
    public interface IPlayer
    {
        Task<PlayerResponse> GetById(int playerId);

        Task<List<PlayerResponse>> GetAll();

        List<PlayerResponse> GetPlayersByTeamIdAndStats(int teamId, List<StatResponse> stats);
    }
}
