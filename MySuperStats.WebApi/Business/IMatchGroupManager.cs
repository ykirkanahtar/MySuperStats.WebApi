using System.Threading.Tasks;
using CustomFramework.BaseWebApi.Utils.Business;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Business
{
    public interface IMatchGroupManager : IBusinessManager<MatchGroup, MatchGroupRequest, int>,
                                            IBusinessManagerUpdate<MatchGroup, MatchGroupRequest, int>
    {
        Task<MatchGroup> GetByGroupNameAsync(string groupName);
        Task<MatchGroup> GetByMatchIdAsync(int matchId);
    }
}