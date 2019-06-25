using System.Collections.Generic;
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
    public class MatchGroupUserManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IMatchGroupUserManager
    {
        private readonly IUnitOfWorkWebApi _uow;

        public MatchGroupUserManager(IUnitOfWorkWebApi uow, ILogger<MatchGroupUserManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
        : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<MatchGroupUser> CreateAsync(MatchGroupUserRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = Mapper.Map<MatchGroupUser>(request);

                /******************References Table Check Values****************/
                /***************************************************************/
                (await _uow.MatchGroups.GetByIdAsync(result.MatchGroupId)).CheckRecordIsExist(typeof(MatchGroup).Name);
                //TODO(await _uow.Players.GetByIdAsync(result.PlayerId)).CheckRecordIsExist(typeof(Player).Name);
                /***************************************************************/
                /***************************************************************/

                _uow.MatchGroupUsers.Add(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.MatchGroupUsers.Delete(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<MatchGroupUser> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
                await _uow.MatchGroupUsers.GetByIdAsync(id)
            , new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<IList<MatchGroup>> GetMatchGroupsByUserIdAsync(int userId)
        {
            return CommonOperationAsync(async () =>
                await _uow.MatchGroupUsers.GetMatchGroupsByUserIdAsync(userId)
            , new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<IList<User>> GetUsersByMatchGroupIdAsync(int matchGroupId)
        {
            return CommonOperationAsync(async () =>
                await _uow.MatchGroupUsers.GetUsersByMatchGroupIdAsync(matchGroupId)
                , new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }
            );
        }
    }
}