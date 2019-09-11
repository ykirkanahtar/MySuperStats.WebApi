using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Identity.Business;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Data;
using MySuperStats.WebApi.Data.Repositories;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Business
{
    public class UserManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IUserManager
    {
        private readonly IUnitOfWorkWebApi _uow;
        private readonly ICustomUserManager<User> _userManager;
        private readonly IUserRepository _userRepository;

        public UserManager(ICustomUserManager<User> userManager, IUserRepository userRepository, IUnitOfWorkWebApi uow, ILogger<UserManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor) : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public Task<IdentityResult> CreateAsync(User user, string password, IUrlHelper url, string requestScheme, string callBackUrl, List<string> roles)
        {
            return CommonOperationAsync(async () =>
            {
                var emailTitle = "ConfirmYourEmailTitle";
                var emailBody = "ConfirmYourEmailBody";

                var result = await _userManager.RegisterWithConfirmationEmailAsync(user, password, roles, url, emailTitle, emailBody, requestScheme, GetUserId(), callBackUrl);
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<IdentityResult> UpdateAsync(int id, User user)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await _userManager.UpdateAsync(user, GetUserId());

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<IdentityResult> DeleteAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var user = await GetByIdAsync(id);

                var result = await _userManager.DeleteAsync(id, GetUserId());

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<User> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                return await _userManager.GetByIdAsync(id);
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<User> GetByIdWithBasketballStats(int id)
        {
            return CommonOperationAsync(async () => await _uow.Users.GetByIdWithBasketballStatsAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<User> GetByUserNameAsync(string userName)
        {
            return CommonOperationAsync(async () =>
            {
                return await _userManager.GetByUserNameAsync(userName);
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<User> GetByEmailAddressAsync(string emailAddress)
        {
            return CommonOperationAsync(async () =>
            {
                return await _userManager.GetByEmailAsync(emailAddress);
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<User> GetUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return CommonOperationAsync(async () =>
            {
                return await _userManager.GetUserAsync(claimsPrincipal);
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<IList<User>> GetAllAsync()
        {
            return CommonOperationAsync(async () =>
            {
                return await _userManager.GetAllAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<IList<User>> GetAllByMatchGroupIdAsync(int matchGroupId)
        {
            return CommonOperationAsync(async () => await _uow.Users.GetAllByMatchGroupIdAsync(matchGroupId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<IdentityResult> ConfirmEmailAsync(int userId, string code)
        {
            return CommonOperationAsync(async () =>
            {
                if (userId < 1 || code == null)
                {
                    throw new ArgumentException($"Hatalı bağlantı"); //Invalid link
                }

                return await _userManager.ConfirmEmailAsync(userId, code);
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task ForgotPasswordAsync(PasswordRecoveryRequest request, IUrlHelper url, string requestScheme, string callBackUrl)
        {
            return CommonOperationAsync(async () =>
            {
                await _userManager.ForgotPasswordAsync(request.EmailAddress, "Parola Yenileme", "Parolanızı yenilemek için lütfen bağlantıya tıklayınız", url, requestScheme, callBackUrl);

                return true;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<IdentityResult> ResetPasswordAsync(PasswordResetRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                return await _userManager.ResetPasswordAsync(request.Email, request.Code, request.Password, request.ConfirmPassword, $"MySuperStats - Parolanız değiştirildi", $"Parolanız değiştirildi.Eğer bu işlemi siz yapmadıysanız lütfen site yöneticisi ile iletişim geçiniz.");
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        // public Task<Role> GetRoleByUserIdAndMatchGroupIdAsync(int userId, int matchGroupId)
        // {
        //     return CommonOperationAsync(async () =>
        //     {
        //         var roles = await _userRepository.GetRolesAsync(userId, matchGroupId);
        //         if(roles.Count > 1) throw new Exception("Sistem hatası, bir kullanıcı birden fazla role sahip olamaz.");

        //         var role = roles.Count == 1 ? roles[0] : new Role();
        //         return role;
        //     }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        // }

        // public Task<UserRole> AddUserToRoleAsync(UserRoleRequest request)
        // {
        //     return CommonOperationAsync(async () =>
        //     {
        //         /* Kullanıcının karşılaşma grubuna ait tüm rolleri siliniyor */
        //         var existingRole = await GetRoleByUserIdAndMatchGroupIdAsync(request.UserId, request.MatchGroupId);
        //         if (existingRole.Name == RoleEnum.Admin.ToString() || request.UserId == GetLoggedInUserId())
        //         {
        //             throw new ArgumentException("Bu işlemi yapmaya yetkiniz yok.");
        //         }

        //         var existingUserRole = new UserRole
        //         {
        //             MatchGroupId = request.MatchGroupId,
        //             RoleId = existingRole.Id,
        //             UserId = request.UserId,
        //         };
        //         _uow.Users.RemoveUserFromRole(existingUserRole);
        //         /* ******************************************************* */

        //         var userRole = Mapper.Map<UserRole>(request);

        //         _uow.Users.AddUserToRole(userRole);
        //         await _uow.SaveChangesAsync();

        //         return userRole;
        //     }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        // }

        // public Task<IList<UserRole>> GetUserRolesByMatchGroupIdAsync(int matchGroupId)
        // {
        //     return CommonOperationAsync(async () =>
        //     {
        //         return await _userRepository.GetUserRolesByMatchGroupIdAsync(matchGroupId);
        //     }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        // }
    }
}
