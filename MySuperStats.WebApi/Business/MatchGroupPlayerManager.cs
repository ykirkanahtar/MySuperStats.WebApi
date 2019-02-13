using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Data;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Business
{
    public class MatchGroupPlayerManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IMatchGroupPlayerManager
    {
        private readonly IUnitOfWorkWebApi _uow;

        public MatchGroupPlayerManager(IUnitOfWorkWebApi uow, ILogger<MatchGroupPlayerManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
        : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<MatchGroupPlayer> CreateAsync(MatchGroupPlayerRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = Mapper.Map<MatchGroupPlayer>(request);

                /******************References Table Check Values****************/
                /***************************************************************/
                (await _uow.MatchGroups.GetByIdAsync(result.MatchGroupId)).CheckRecordIsExist(typeof(MatchGroup).Name);
                (await _uow.Players.GetByIdAsync(result.PlayerId)).CheckRecordIsExist(typeof(Player).Name);
                /***************************************************************/
                /***************************************************************/

                _uow.MatchGroupPlayers.Add(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.MatchGroupPlayers.Delete(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<MatchGroupPlayer> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
                await _uow.MatchGroupPlayers.GetByIdAsync(id)
            , new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<ICustomList<MatchGroup>> GetMatchGroupsByPlayerIdAsync(int playerId)
        {
            return CommonOperationAsync(async () =>
                await _uow.MatchGroupPlayers.GetMatchGroupsByPlayerIdAsync(playerId)
            , new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<ICustomList<Player>> GetPlayersByMatchGroupIdAsync(int matchGroupId)
        {
            return CommonOperationAsync(async () =>
                await _uow.MatchGroupPlayers.GetPlayersByMatchGroupIdAsync(matchGroupId)
                , new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }
            );
        }
    }
}