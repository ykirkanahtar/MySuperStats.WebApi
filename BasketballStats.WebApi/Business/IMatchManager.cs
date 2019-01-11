using System.Threading.Tasks;
using BasketballStats.Contracts.Requests;
using BasketballStats.Contracts.Responses;
using BasketballStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;

namespace BasketballStats.WebApi.Business
{
    public interface IMatchManager : IBusinessManager<Match, MatchRequest, int>
    , IBusinessManagerUpdate<Match, MatchRequest, int>
    {
        Task<ICustomList<Match>> GetAllAsync();
        Task<ICustomList<MatchForMainScreen>> GetMatchForMainScreen();
        Task<MatchDetailStats> GetMatchDetailStats(int matchId);
    }
}
