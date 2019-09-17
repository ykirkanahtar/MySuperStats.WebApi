using AutoMapper;
using MySuperStats.WebApi.ApplicationSettings;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CS.Common.EmailProvider;
using MySuperStats.WebApi.Models;
using CustomFramework.WebApiUtils.Controllers;
using CustomFramework.WebApiUtils.Contracts;
using System.Collections.Generic;
using MySuperStats.Contracts.Responses;
using System.Threading.Tasks;
using CustomFramework.Authorization.Attributes;
using MySuperStats.WebApi.Enums;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Utils.Exceptions;
using System;
using CustomFramework.WebApiUtils.Identity.Constants;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Business;
using MySuperStats.Contracts.Enums;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using MySuperStats.WebApi.Constants;
using Microsoft.AspNetCore.Authorization;

namespace MySuperStats.WebApi.Controllers.Authorization
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route(ApiConstants.DefaultRoute + nameof(User))]
    public class UserController : BaseController
    {
        private readonly IUserManager _userManager;
        private readonly IPermissionChecker _permissionChecker;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IHttpContextAccessor httpContextAccessor, IPermissionChecker permissionChecker, ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IUserManager userManager, IEmailSender emailSender)
            : base(localizationService, logger, mapper)
        {
            _userManager = userManager;
            _permissionChecker = permissionChecker;
            _httpContextAccessor = httpContextAccessor;
        }

        [Route("{id:int}/update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UserUpdateRequest request)
        {
            var loggedUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (loggedUserId != id) //Eğer giriş yapan kullanıcı, farklı kullanıcıya ait bilgileri güncellemek istiyorsa yetkisi kontrol ediliyor
            {
                var attributes = new List<PermissionAttribute> {
                    new PermissionAttribute(nameof(PermissionEnum.UpdateUser), nameof(BooleanEnum.True))
                 };
                await _permissionChecker.HasPermissionAsync(User, 0, attributes);
            }

            if (!ModelState.IsValid)
                throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

            var result = await CommonOperationAsync<User>(async () =>
            {
                var user = await _userManager.GetByIdAsync(id);
                if (user == null)
                    throw new KeyNotFoundException(IdentityStringMessages.User);

                Mapper.Map(request, user);

                var response = await _userManager.UpdateAsync(id, user);
                if (!response.Succeeded)
                {
                    foreach (var error in response.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
                }

                return user;
            });

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<User, UserResponse>(result)));
        }

        [Route("{id:int}/update/email/request")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmailAsync(int id, [FromBody] UserEmailUpdateRequest request)
        {
            var loggedUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (loggedUserId != id) //Eğer giriş yapan kullanıcı, farklı kullanıcıya ait bilgileri güncellemek istiyorsa yetkisi kontrol ediliyor
            {
                var attributes = new List<PermissionAttribute> {
                    new PermissionAttribute(nameof(PermissionEnum.UpdateEmail), nameof(BooleanEnum.True))
                 };
                await _permissionChecker.HasPermissionAsync(User, 0, attributes);
            }

            if (!ModelState.IsValid)
                throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

            var result = await CommonOperationAsync<bool>(async () =>
            {
                var user = await _userManager.GetByIdAsync(id);
                if (user == null)
                    throw new KeyNotFoundException(IdentityStringMessages.User);

                await _userManager.GenerateTokenForChangeEmailAsync(user, request.NewEmail, Url, Request.Scheme);
                return true;
            });

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(result));
        }

        [Route("update/email/confirm/userId/{userId:int}/newEmail/{email}/code/{code}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateEmailConfirmationAsync(int userId, string email, string code)
        {
            var result = await _userManager.ChangeEmailAsync(userId, email, code);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                throw new ArgumentException($"E-posta doğrulaması sırasında hata oluştu : {ModelState.ModelStateToString(LocalizationService)}"); //Error confirming email for user with ID '{userId}':
            }

            return Ok("Yeni E-Posta adresiniz onaylanmıştır");
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(SpecialEnums.OnlyAdmin), nameof(BooleanEnum.True))]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _userManager.DeleteAsync(id);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }

        [Route("get/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await CommonOperationAsync<User>(async () =>
            {
                return await _userManager.GetByIdAsync(id);
            });
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<User, UserResponse>(result)));
        }

        [Route("get/email/{emailAddress}")]
        [HttpGet]
        public async Task<IActionResult> GetByEmailAddressAsync(string emailAddress)
        {
            var result = await CommonOperationAsync<User>(async () =>
            {
                return await _userManager.GetByEmailAddressAsync(emailAddress);
            });
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<User, UserResponse>(result)));
        }

        [Route("getwithbasketballstats/id/{id:int}")]
        [HttpGet]
        public Task<IActionResult> GetWithBasketballStatsById(int id)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await _userManager.GetByIdWithBasketballStats(id);
                var userDetailResponse = Mapper.Map<User, UserDetailResponse>(result);
                userDetailResponse.SetFields();
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(userDetailResponse));
            });
        }

        [Route("getall/matchgroupid/{matchGroupId:int}")]
        [HttpGet]
        public async Task<IActionResult> GetAllByMatchGroupIdAsync(int matchGroupId)
        {
            var result = await CommonOperationAsync<IList<User>>(async () =>
            {
                return await _userManager.GetAllByMatchGroupIdAsync(matchGroupId);
            });

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<User>, IList<UserResponse>>(result), result.Count));
        }

        // [Route("getallwithroles/matchgroupid/{matchGroupId:int}")]
        // [HttpGet]
        // public async Task<IActionResult> GetUserRolesByMatchGroupIdAsync(int matchGroupId)
        // {
        //     return await CommonOperationAsync<IActionResult>(async () =>
        //     {
        //         var result = await _userManager.GetUserRolesByMatchGroupIdAsync(matchGroupId);
        //         return Ok(new ApiResponse(LocalizationService, Logger).Ok(
        //             Mapper.Map<IList<UserRole>, IList<UserRoleResponse>>(result), result.Count));
        //     });
        // }

        // [Route("addtorole")]
        // [HttpPost]
        // public Task<IActionResult> AddToRoleAsync([FromBody] UserRoleRequest request)
        // {
        //     return CommonOperationAsync<IActionResult>(async () =>
        //     {
        //         var attributes = new List<PermissionAttribute> {
        //         new PermissionAttribute(nameof(PermissionEnum.AddUserToRole), nameof(BooleanEnum.True))
        //         };
        //         await _permissionChecker.HasPermissionAsync(User, request.MatchGroupId, attributes);

        //         var role = await _roleManager.GetByNameAsync(request.RoleName);
        //         request.RoleId = role.Id;
        //         var result = await _userManager.AddUserToRoleAsync(request);
        //         return Ok(new ApiResponse(LocalizationService, Logger).Ok((result)));
        //     });
        // }
    }
}
