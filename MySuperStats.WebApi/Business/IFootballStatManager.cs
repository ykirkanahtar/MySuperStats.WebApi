using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.BaseWebApi.Utils.Business;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Business
{
    public interface IFootballStatManager : IBusinessManager<FootballStat, FootballStatRequest, int>
    , IBusinessManagerUpdate<FootballStat, FootballStatRequest, int>
    {
        Task<int> CreateMultiStats(CreateMatchRequestWithMultiFootballStats request);
        Task<IList<FootballStat>> GetAllByMatchIdAsync(int matchId);
        Task<IList<FootballStat>> GetAllByMatchGroupIdAndPlayerIdAsync(int matchGroupId, int playerId);
        Task<IList<FootballStat>> GetAllByMatchGroupIdAsync(int matchGroupId);
        Task<FootballStatisticTable> GetTopStats(int matchGroupId);
    }
}