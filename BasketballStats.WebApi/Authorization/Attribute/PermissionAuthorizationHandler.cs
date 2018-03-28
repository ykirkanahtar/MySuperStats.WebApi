using BasketballStats.WebApi;
using BasketballStats.WebApi.Authorization;
using BasketballStats.WebApi.Authorization.Business.Contracts;
using BasketballStats.WebApi.Authorization.Enums;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Contracts;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BasketballStats.WebApi.Authorization
{
    public class TestAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorizationToken);
            base.OnActionExecuting(context);
        }
    }

    public class PermissionAuthorizationHandler : AttributeAuthorizationHandler<PermissionAuthorizationRequirement, PermissionAttribute>
    {
        private readonly IApiRequest _apiRequest;
        private readonly IUserRoleManager _userRoleManager;
        private readonly IClaimManager _claimManager;

        private readonly IRoleClaimManager _roleClaimManager;
        private readonly IUserClaimManager _userClaimManager;

        private readonly IRoleEntityClaimManager _roleEntityClaimManager;
        private readonly IUserEntityClaimManager _userEntityClaimManager;

        public PermissionAuthorizationHandler(IApiRequestAccessor apiRequestAccessor, IUserRoleManager userRoleManager, IClaimManager claimManager, IRoleClaimManager roleClaimManager, IUserClaimManager userClaimManager, IRoleEntityClaimManager roleEntityClaimManager, IUserEntityClaimManager userEntityClaimManager)
        {
            _apiRequest = apiRequestAccessor.GetApiRequest<ApiRequest>();
            _userRoleManager = userRoleManager;
            _claimManager = claimManager;
            _roleClaimManager = roleClaimManager;
            _userClaimManager = userClaimManager;
            _roleEntityClaimManager = roleEntityClaimManager;
            _userEntityClaimManager = userEntityClaimManager;
        }


        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement,
            IEnumerable<PermissionAttribute> attributes)
        {
            var claimsPrincipal = context.User;

            UserIsAuthenticated(claimsPrincipal);

            try
            {
                var userId = _apiRequest.User.Id;
                var roles = (await _userRoleManager.GetRolesByUserIdAsync(userId)).EntityList;

                foreach (var permissionAttribute in attributes)
                {
                    if (permissionAttribute.CustomClaim != null)
                    {
                        await CheckCustomClaimAsync(userId, roles, (CustomClaim)permissionAttribute.CustomClaim);
                    }
                    else if (permissionAttribute.Entity != null && permissionAttribute.Crud != null)
                    {
                        await CheckEntityClaimAsync(userId, roles, (Entity)permissionAttribute.Entity, (Crud)permissionAttribute.Crud);
                    }
                    else
                    {
                        throw new KeyNotFoundException();
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                throw new UnauthorizedAccessException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            context.Succeed(requirement);
        }

        private void UserIsAuthenticated(ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null || claimsPrincipal.Identity.IsAuthenticated == false)
            {
                throw new UnauthorizedAccessException(DefaultResponseMessages.UnauthorizedAccessError);
            }
        }

        private async Task CheckCustomClaimAsync(int userId, IList<Role> roles, CustomClaim customClaim)
        {
            var claim = await _claimManager.GetByCustomClaimAsync(customClaim);
            await AuthorizeWithCustomClaimAsync(userId, roles, claim.Id);
        }

        private async Task CheckEntityClaimAsync(int userId, IList<Role> roles, Entity entity, Crud crud)
        {
            await AuthorizeWithEntityClaimAsync(userId, roles, entity, crud);
        }

        private async Task<bool> AuthorizeWithCustomClaimAsync(int userId, IList<Role> roles, int claimId)
        {
            var userIsAuthorized = await _userClaimManager.UserIsAuthorizedForClaimAsync(userId, claimId);
            var roleIsAuthorized = await _roleClaimManager.RolesAreAuthorizedForClaimAsync(roles, claimId);
            if (userIsAuthorized || roleIsAuthorized)
            {
                return true;
            }

            throw new KeyNotFoundException();
        }

        private async Task<bool> AuthorizeWithEntityClaimAsync(int userId, IList<Role> roles, Entity entity, Crud crud)
        {
            var userIsAuthorized = await _userEntityClaimManager.UserIsAuthorizedForEntityClaimAsync(userId, entity, crud);
            var roleIsAuthorized = await _roleEntityClaimManager.RolesAreAuthorizedForClaimAsync(roles, entity, crud);

            if (userIsAuthorized || roleIsAuthorized)
            {
                return true;
            }

            throw new KeyNotFoundException();
        }

    }
}
