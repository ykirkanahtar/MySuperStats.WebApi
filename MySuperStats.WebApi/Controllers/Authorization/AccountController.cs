using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.WebApiUtils.Constants;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Identity.Business;
using CustomFramework.WebApiUtils.Identity.Constants;
using CustomFramework.WebApiUtils.Identity.Controllers;
using CustomFramework.WebApiUtils.Contracts.Resources;
using CustomFramework.WebApiUtils.Utils.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.ApplicationSettings;
using MySuperStats.WebApi.Business;
using MySuperStats.WebApi.Data;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Controllers.Authorization
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route(ApiConstants.DefaultRoute + "Account")]
    public class AccountController : BaseAccountController<User, Role, ApplicationContext>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IClientApplicationManager _clientApplicationManager;
        private readonly IUserManager _userManager;

        public AccountController(
            SignInManager<User> signInManager
            , IClientApplicationManager clientApplicationManager
            , ILocalizationService localizationService
            , ILogger<Controller> logger
            , IMapper mapper
            , IUserManager userManager
            )
        : base(localizationService, logger, mapper)
        {
            _signInManager = signInManager;
            _clientApplicationManager = clientApplicationManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

            var userResponse = await CommonOperationAsync<User>(async () =>
            {
                var user = Mapper.Map<User>(request);
                var roles = new List<string>();

                var result = await _userManager.CreateAsync(user, request.Password, Url, Request.Scheme, request.CallBackUrl, roles);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
                }

                return user;
            });

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<User, UserResponse>(userResponse)));
        }

        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] Login login)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, true);
            if (!result.Succeeded)
            {
                throw new AuthenticationException(IdentityStringMessages.AuthenticationError);
            }

            var user = await _userManager.GetByUserNameAsync(login.UserName);
            if (user == null)
                throw new Exception(DefaultResponseMessages.AnErrorHasOccured);

            var clientApplication =
                await _clientApplicationManager.LoginAsync(login.ClientApplicationCode,
                    login.ClientApplicationPassword);

            var apiRequest = new ApiRequest(0, user.Id,
                clientApplication.Id);

            var tokenResponse = GenerateJwtToken(user.Id, apiRequest);

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(tokenResponse));
        }

        [Route("Logout")]
        [HttpPost]
        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("ConfirmEmail/userId/{userId:int}/code/{code}")]
        public async Task<IActionResult> ConfirmEmailAsync(int userId, string code)
        {
            var result = await _userManager.ConfirmEmailAsync(userId, code);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                throw new ArgumentException($"E-posta doğrulaması sırasında hata oluştu : {ModelState.ModelStateToString(LocalizationService)}"); //Error confirming email for user with ID '{userId}':
            }

            return Ok("Hesabınız onaylanmıştır");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPasswordAsync([FromBody] PasswordRecoveryRequest request)
        {
            await _userManager.ForgotPasswordAsync(request, Url, Request.Scheme, request.CallBackUrl);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] PasswordResetRequest request)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

            var result = await _userManager.ResetPasswordAsync(request);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
            }

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }
    }
}