using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CustomFramework.BaseWebApi.Authorization.Attributes;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Responses;

namespace MySuperStats.WebApi.Business
{
    public interface IPermissionChecker
    {
        Task<bool> HasPermissionAsync(ClaimsPrincipal user, int matchGroupId, IList<PermissionAttribute> permissionAttributes);
        Task<bool> HasPermissionByMatchIdAsync(ClaimsPrincipal user, IList<PermissionAttribute> permissionAttributes, int matchId);
        Task<PermissionCheckerResponse> HasPermissionAsyncByUserIdAndMatchGroupIdAsync(int userId, int matchGroupId, List<PermissionEnum> permissionEnums);
    }
}