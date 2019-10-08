using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Contracts.Resources;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Data;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Business
{
    public class MatchGroupUserManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IMatchGroupUserManager
    {
        private readonly IUnitOfWorkWebApi _uow;
        private readonly ILocalizationService _localizer;

        public MatchGroupUserManager(IUnitOfWorkWebApi uow, ILogger<MatchGroupUserManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor, ILocalizationService localizer)
        : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
            _localizer = localizer;
        }

        public Task<MatchGroupUser> CreateAsync(MatchGroupPlayerRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = Mapper.Map<MatchGroupUser>(request);

                /******************References Table Check Values****************/
                /***************************************************************/
                (await _uow.MatchGroups.GetByIdAsync(result.MatchGroupId)).CheckRecordIsExist(nameof(MatchGroup));
                (await _uow.Players.GetByIdAsync(result.PlayerId)).CheckRecordIsExist(nameof(Player));
                /***************************************************************/
                /***************************************************************/

                /******************Check other controls****************/
                /******************************************************/
                var user = await _uow.Players.GetUserByIdAsync(result.PlayerId);

                var playerInMatchGroupUser = await _uow.MatchGroupUsers.PlayerIsInMatchGroupAsync(request.MatchGroupId, result.PlayerId);
                if (playerInMatchGroupUser) throw new DuplicateNameException(nameof(Player));

                if (user != null)
                {
                    result.UserId = user.Id;
                    var userInMatchGroupUser = await _uow.MatchGroupUsers.UserIsInMatchGroupAsync(request.MatchGroupId, (int)result.UserId);
                    if (userInMatchGroupUser) throw new DuplicateNameException(nameof(User));
                }
                /******************************************************/
                /******************************************************/


                _uow.MatchGroupUsers.Add(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<MatchGroupUser> UpdateRoleAsync(MatchGroupUserRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var matchGroupUser = await GetByMatchGroupIdAndUserIdAsync(request.MatchGroupId, request.UserId);
                var existingRole = matchGroupUser.Role;
                var newRole = (RoleEnum)request.RoleId;

                if (existingRole.Name == RoleEnum.Admin.ToString() || request.UserId == GetLoggedInUserId() || newRole == RoleEnum.Admin)
                {
                    throw new ArgumentException(_localizer.GetValue("UnauthorizedAccessError"));
                }

                matchGroupUser.RoleId = request.RoleId;

                _uow.MatchGroupUsers.Update(matchGroupUser, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

                return matchGroupUser;
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

        public Task<MatchGroupUser> GetByMatchGroupIdAndUserIdAsync(int matchGroupId, int userId)
        {
            return CommonOperationAsync(async () =>
                await _uow.MatchGroupUsers.GetByMatchGroupIdAndUserIdAsync(matchGroupId, userId)
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

        public Task<IList<MatchGroupUser>> GetAllUsersByMatchGroupIdAsync(int matchGroupId)
        {
            return CommonOperationAsync(async () =>
                await _uow.MatchGroupUsers.GetAllUsersByMatchGroupIdAsync(matchGroupId)
                , new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }
            );
        }
    }
}