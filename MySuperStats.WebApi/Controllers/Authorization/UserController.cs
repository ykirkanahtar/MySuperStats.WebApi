using AutoMapper;
using MySuperStats.WebApi.ApplicationSettings;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomFramework.WebApiUtils.Identity.Controllers;
using Microsoft.AspNetCore.Identity;
using CustomFramework.WebApiUtils.Identity.Models;
using CS.Common.EmailProvider;
using CustomFramework.WebApiUtils.Identity.Business;
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

namespace MySuperStats.WebApi.Controllers.Authorization
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route(ApiConstants.DefaultRoute + nameof(User))]
    public class UserController : BaseController
    {
        private readonly IUserManager _userManager;

        public UserController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IUserManager userManager, IEmailSender emailSender)
            : base(localizationService, logger, mapper)
        {
            _userManager = userManager;
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(SpecialEnums.OnlyAdmin), nameof(BooleanEnum.True))]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UserUpdateRequest request)
        {
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

        [Route("getall")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await CommonOperationAsync<IList<User>>(async () =>
            {
                return await _userManager.GetAllAsync();
            });

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<User>, IList<UserResponse>>(result), result.Count));
        }

    }
}
