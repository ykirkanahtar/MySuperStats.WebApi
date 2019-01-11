using BasketballStats.Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballStats.WebSite.Business
{
    public interface IPlayer
    {
        Task<PlayerDetailResponse> GetWithStatsById(int playerId);

        Task<List<PlayerResponse>> GetAll();
    }
}
