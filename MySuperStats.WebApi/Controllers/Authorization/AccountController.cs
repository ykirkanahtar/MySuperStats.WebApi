using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;
using AutoMapper;
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
using CustomFramework.BaseWebApi.Contracts.ApiContracts;
using CustomFramework.BaseWebApi.Utils.Contracts;
using CustomFramework.BaseWebApi.Identity.Controllers;
using CustomFramework.BaseWebApi.Identity.Business;
using CustomFramework.BaseWebApi.Resources;
using CustomFramework.BaseWebApi.Utils.Utils.Exceptions;
using CustomFramework.BaseWebApi.Utils.Constants;

namespace MySuperStats.WebApi.Controllers.Authorization
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route(ApiConstants.DefaultRoute + "Account")]
    public class AccountController : BaseAccountController<User, Role, ApplicationContext>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IClientApplicationManager _clientApplicationManager;
        private readonly IUserManager _userManager;
        private readonly IPlayerManager _playerManager;
        public AccountController(
            SignInManager<User> signInManager
            , IClientApplicationManager clientApplicationManager
            , ILocalizationService localizationService
            , ILogger<Controller> logger
            , IMapper mapper
            , IUserManager userManager
            , IPlayerManager playerManager)
        : base(localizationService, logger, mapper)
        {
            _signInManager = signInManager;
            _clientApplicationManager = clientApplicationManager;
            _userManager = userManager;
            _playerManager = playerManager;
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

                user.TempFirstName = request.FirstName;
                user.TempLastName = request.LastName;
                user.TempBirthDate = request.BirthDate;

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

            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, true);
            if (!result.Succeeded)
            {
                throw new AuthenticationException("AuthenticationError");
            }

            var user = await _userManager.GetByEmailAddressAsync(login.Email);
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
            var userResponse = await CommonOperationAsync<User>(async () =>
            {
                var result = await _userManager.ConfirmEmailAsync(userId, code);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    throw new ArgumentException($"{LocalizationService.GetValue("Email confirmation error")}: {ModelState.ModelStateToString(LocalizationService)}"); //Error confirming email for user with ID '{userId}':
                }

                var user = await _userManager.GetByIdAsync(userId);

                var createPlayerRequest = new CreatePlayerRequest
                {
                    BirthDate = (DateTime)user.TempBirthDate,
                    FirstName = user.TempFirstName,
                    LastName = user.TempLastName,
                };

                var playerResult = await _playerManager.CreateAsync(createPlayerRequest, user.Id);

                await _userManager.ClearTempFielsAsync(user);
                return user;
            });

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(LocalizationService.GetValue("Email is approved")));
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