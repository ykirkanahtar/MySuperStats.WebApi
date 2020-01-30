using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Data;
using MySuperStats.WebApi.Models;
using MySuperStats.WebApi.Constants;
using System.Reflection;
using CustomFramework.BaseWebApi.Utils.Utils;
using MySuperStats.Contracts.Enums;
using CustomFramework.BaseWebApi.Utils.Business;
using CustomFramework.BaseWebApi.Utils.Enums;
using CustomFramework.BaseWebApi.Contracts.ApiContracts;

namespace MySuperStats.WebApi.Business
{
    public class MatchGroupManager : BaseBusinessManagerWithApiRequest<ApiRequest>,
                                        IMatchGroupManager
    {
        private readonly IUnitOfWorkWebApi _uow;
        private readonly IMatchGroupUserManager _matchGroupUserManager;

        public MatchGroupManager(IMatchGroupUserManager matchGroupUserManager, IUnitOfWorkWebApi uow, ILogger<MatchGroupManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor) : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
            _matchGroupUserManager = matchGroupUserManager;
        }

        public Task<MatchGroup> CreateAsync(MatchGroupRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = Mapper.Map<MatchGroup>(request);

                /**************GroupName is unique*****************/
                /**************************************************/
                var groupNameUniqueResult = await _uow.MatchGroups.GetByGroupNameAsync(result.GroupName);

                groupNameUniqueResult.CheckUniqueValue(nameof(request.GroupName));
                /**************GroupName is unique*****************/
                /**************************************************/

                _uow.MatchGroups.Add(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
                
                var userId = GetLoggedInUserId();
                var userPlayer = await _uow.Users.GetPlayerByIdAsync(userId);

                var matchGroupUserRequest = new MatchGroupPlayerRequest
                {
                    MatchGroupId = result.Id,
                    RoleId = (int)RoleEnum.GroupAdmin,
                    PlayerId = userPlayer.Id
                };
                await _matchGroupUserManager.CreateAsync(matchGroupUserRequest);

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<MatchGroup> UpdateAsync(int id, MatchGroupRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                /**************GroupName is unique*****************/
                /**************************************************/
                var groupNameUniqueResult = await _uow.MatchGroups.GetByGroupNameAsync(result.GroupName);

                groupNameUniqueResult.CheckUniqueValueForUpdate(result.Id, nameof(result.GroupName));
                /**************GroupName is unique*****************/
                /**************************************************/

                _uow.MatchGroups.Update(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.MatchGroups.Delete(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<MatchGroup> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.MatchGroups.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
            BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<MatchGroup> GetByMatchIdAsync(int matchId)
        {
            return CommonOperationAsync(async () => await _uow.MatchGroups.GetByMatchIdAsync(matchId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
            BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }        

        public Task<MatchGroup> GetByGroupNameAsync(string groupName)
        {
            return CommonOperationAsync(async () => await _uow.MatchGroups.GetByGroupNameAsync(groupName), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
            BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }
    }
}