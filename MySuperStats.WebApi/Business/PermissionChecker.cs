using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Identity.Business;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Enums;

namespace MySuperStats.WebApi.Business
{
    public class PermissionChecker : IPermissionChecker
    {
        private readonly IPermissionManager _permissionManager;
        private readonly IUserManager _userManager;
        private readonly IMatchManager _matchManager;

        public PermissionChecker(IPermissionManager permissionManager, IUserManager userManager, IMatchManager matchManager)
        {
            _permissionManager = permissionManager;
            _userManager = userManager;
            _matchManager = matchManager;
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
            var roles = await _userManager.GetRolesAsync(userId, matchGroupId);
            var rolesNames = new List<string>();
            foreach (var role in roles)
            {
                rolesNames.Add(role.Name);
            }
            await _permissionManager.HasPermission(permissionAttributes, rolesNames);
            return true;
        }
    }
}