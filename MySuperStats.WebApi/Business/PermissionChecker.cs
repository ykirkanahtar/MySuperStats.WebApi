using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CustomFramework.BaseWebApi.Authorization.Attributes;
using CustomFramework.BaseWebApi.Authorization.Enums;
using CustomFramework.BaseWebApi.Identity.Business;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Responses;

namespace MySuperStats.WebApi.Business
{
    public class PermissionChecker : IPermissionChecker
    {
        private readonly IPermissionManager _permissionManager;
        private readonly IMatchGroupUserManager _matchGroupUserManager;
        private readonly IMatchManager _matchManager;
        private readonly IUserManager _userManager;

        public PermissionChecker(IPermissionManager permissionManager, IUserManager userManager, IMatchGroupUserManager matchGroupUserManager, IMatchManager matchManager)
        {
            _permissionManager = permissionManager;
            _matchGroupUserManager = matchGroupUserManager;
            _matchManager = matchManager;
            _userManager = userManager;
        }

        public async Task<bool> HasPermissionAsync(ClaimsPrincipal user, int matchGroupId, IList<PermissionAttribute> permissionAttributes)
        {
            var userId = Convert.ToInt32(user.FindFirstValue(ClaimTypes.NameIdentifier));
            return await HasPermissionAsync(userId, matchGroupId, permissionAttributes);
        }

        public async Task<bool> HasPermissionByMatchIdAsync(ClaimsPrincipal user, IList<PermissionAttribute> permissionAttributes, int matchId)
        {
            var matchDetail = await _matchManager.GetByIdAsync(matchId);

            return await HasPermissionAsync(user, matchDetail.MatchGroupId, permissionAttributes);
        }

        public async Task<PermissionCheckerResponse> HasPermissionAsyncByUserIdAndMatchGroupIdAsync(int userId, int matchGroupId, List<PermissionEnum> permissionEnums)
        {
            var response = new PermissionCheckerResponse
            {
                MatchGroupId = matchGroupId,
                UserId = userId,
            };

            var permissions = new Dictionary<string, bool>();

            foreach (var permissionEnum in permissionEnums)
            {
                var hasPermission = false;
                var permissionAttribute = new PermissionAttribute(permissionEnum.ToString(), nameof(BooleanEnum.True));
                try
                {
                    await HasPermissionAsync(userId, matchGroupId, new List<PermissionAttribute> { permissionAttribute });
                    hasPermission = true;
                }
                catch (UnauthorizedAccessException)
                {
                    hasPermission = false;
                }
                permissions.Add(permissionEnum.ToString(), hasPermission);
            }
            response.PermissionDetails = permissions;
            return response;
        }

        private async Task<bool> HasPermissionAsync(int userId, int matchGroupId, IList<PermissionAttribute> permissionAttributes)
        {
            var rolesNames = new List<string>();

            var userRole = await _userManager.GetRoleByUserIdAsync(userId);
            if (userRole != null)
            {
                rolesNames.Add(userRole.Name);
            }

            if (matchGroupId > 0)
            {
                var matchGroupUser = await _matchGroupUserManager.GetByMatchGroupIdAndUserIdAsync(matchGroupId, userId);
                rolesNames.Add(matchGroupUser.Role.Name);
            }

            if (rolesNames.Count > 0)
                await _permissionManager.HasPermission(permissionAttributes, rolesNames);
            else
                throw new UnauthorizedAccessException();

            return true;
        }
    }
}