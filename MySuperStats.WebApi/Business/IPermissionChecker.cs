using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CustomFramework.Authorization.Attributes;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Enums;

namespace MySuperStats.WebApi.Business
{
    public interface IPermissionChecker
    {
        Task<bool> HasPermissionAsync(ClaimsPrincipal user, int matchGroupId, IList<PermissionAttribute> permissionAttributes);
        Task<bool> HasPermissionByMatchIdAsync(ClaimsPrincipal user, IList<PermissionAttribute> permissionAttributes, int matchId);
        Task<PermissionCheckerResponse> HasPermissionAsyncByUserIdAndMatchGroupIdAsync(int userId, int matchGroupId, List<PermissionEnum> permissionEnums);
    }
}