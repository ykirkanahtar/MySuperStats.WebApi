using System.Threading.Tasks;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Models;
using CustomFramework.WebApiUtils.Business;
using System.Collections.Generic;

namespace MySuperStats.WebApi.Business
{
    public interface IMatchManager : IBusinessManager<Match, MatchRequest, int>
    , IBusinessManagerUpdate<Match, MatchRequest, int>
    {
        Task<IList<Match>> GetAllByMatchGroupIdAsync(int matchGroupId);
        Task<IList<Match>> GetMatchForMainScreen(int matchGroupId);
        Task<Match> GetMatchDetailBasketballStats(int matchId);
    }
}
