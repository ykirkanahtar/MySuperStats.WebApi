using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Business
{
    public interface IMatchGroupManager : IBusinessManager<MatchGroup, MatchGroupRequest, int>,
                                            IBusinessManagerUpdate<MatchGroup, MatchGroupRequest, int>
    {
        Task<MatchGroup> GetByGroupNameAsync(string groupName);
    }
}