using System.Threading.Tasks;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;

namespace MySuperStats.WebApi.Business
{
    public interface IMatchManager : IBusinessManager<Match, MatchRequest, int>
    , IBusinessManagerUpdate<Match, MatchRequest, int>
    {
        Task<ICustomList<Match>> GetAllAsync();
        Task<ICustomList<MatchForMainScreen>> GetMatchForMainScreen();
        Task<MatchDetailStats> GetMatchDetailStats(int matchId);
    }
}
