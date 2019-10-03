using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CS.Common.EmailProvider;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Contracts.Resources;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Identity.Business;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.ApplicationSettings;
using MySuperStats.WebApi.Constants;
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
        private readonly IEmailSender _emailSender;
        private readonly IAppSettings _appSettings;
        private readonly ILocalizationService _localizer;

        public UserManager(ICustomUserManager<User> userManager, IUserRepository userRepository, IEmailSender emailSender, IAppSettings appSettings, IUnitOfWorkWebApi uow, ILogger<UserManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor, ILocalizationService localizer)
        : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
            _userManager = userManager;
            _userRepository = userRepository;
            _appSettings = appSettings;
            _emailSender = emailSender;
            _localizer = localizer;
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
                var result = await _userManager.UpdateAsync(user, GetLoggedInUserId());

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<IdentityResult> DeleteAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var user = await GetByIdAsync(id);

                var result = await _userManager.DeleteAsync(id, GetLoggedInUserId());

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task GenerateTokenForChangeEmailAsync(User user, string newEmail, IUrlHelper url, string requestScheme)
        {
            return CommonOperationAsync(async () =>
            {
                if (user.Email == newEmail)
                    throw new ArgumentException(_localizer.GetValue("Your new e-mail address must be different from your registered e-mail address"));

                var token = await _userManager.GenerateTokenForChangeEmailAsync(user, newEmail);

                var codeBytes = Encoding.UTF8.GetBytes(token);
                var codeEncoded = WebEncoders.Base64UrlEncode(codeBytes);

                var callbackUrl = url.Action(
                     action: "UpdateEmailConfirmationAsync",
                     controller: "User",
                     values: new { userId = user.Id, email = newEmail, code = codeEncoded },
                     protocol: requestScheme);

                await _emailSender.SendEmailAsync(
                    _appSettings.SenderEmailAddress, newEmail
                    , AppConstants.UpdateEmailAddressEmailTitle, $"{AppConstants.UpdateEmailAddressEmailText} {callbackUrl}");
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<User> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                return await _userManager.GetByIdAsync(id);
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<UserDetailWithBasketballStat> GetByIdWithBasketballStatsAsync(int id)
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
                    throw new ArgumentException(_localizer.GetValue("Invalid link")); //Invalid link
                }

                return await _userManager.ConfirmEmailAsync(userId, code);
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<IdentityResult> ChangeEmailAsync(int userId, string newEmail, string token)
        {
            return CommonOperationAsync(async () =>
            {
                if (userId < 1 || token == null)
                {
                    throw new ArgumentException(_localizer.GetValue("Invalid link")); //Invalid link
                }

                var codeDecodedBytes = WebEncoders.Base64UrlDecode(token);
                var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

                return await _userManager.ChangeEmailAsync(userId, newEmail, codeDecoded);
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task ForgotPasswordAsync(PasswordRecoveryRequest request, IUrlHelper url, string requestScheme, string callBackUrl)
        {
            return CommonOperationAsync(async () =>
            {
                await _userManager.ForgotPasswordAsync(request.EmailAddress, _localizer.GetValue("Renew Password"), _localizer.GetValue("For renew your password, please click on the link"), url, requestScheme, callBackUrl);

                return true;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<IdentityResult> ResetPasswordAsync(PasswordResetRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                return await _userManager.ResetPasswordAsync(request.Email, request.Code, request.Password, request.ConfirmPassword
                , $"MySuperStats - {_localizer.GetValue("Your password has been changed")}"
                , $"{_localizer.GetValue("Your password has been changed email text")}");
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Role> GetRoleByUserIdAsync(int userId)
        {
            return CommonOperationAsync(async () =>
            {
                var roles = await _userRepository.GetRolesByUserIdAsync(userId);
                if (roles.Count > 1) throw new Exception($"{_localizer.GetValue("SystemError")}, {_localizer.GetValue("A user cannot have more than one role.")}");

                var role = roles.Count == 1 ? roles[0] : new Role();
                return role;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }
    }
}
