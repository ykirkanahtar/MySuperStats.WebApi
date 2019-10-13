using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Contracts.Resources;
using CustomFramework.WebApiUtils.Controllers;
using CustomFramework.WebApiUtils.Utils.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.ApplicationSettings;
using MySuperStats.WebApi.Business;
using MySuperStats.WebApi.Enums;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Controllers
{
    [Route(ApiConstants.DefaultRoute + "player")]
    public class PlayerController : BaseController
    {
        private readonly IPlayerManager _playerManager;
        private readonly IPermissionChecker _permissionChecker;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PlayerController(IHttpContextAccessor httpContextAccessor, IPermissionChecker permissionChecker, ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IPlayerManager playerManager)
            : base(localizationService, logger, mapper)
        {
            _playerManager = playerManager;
            _permissionChecker = permissionChecker;
            _httpContextAccessor = httpContextAccessor;
        }

        [Route("createguestplayer")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlayerRequest request)
        {
            var attributes = new List<PermissionAttribute> {
                new PermissionAttribute(nameof(PermissionEnum.CreateMatchGroupUser), nameof(BooleanEnum.True))
            };
            await _permissionChecker.HasPermissionAsync(User, request.MatchGroupId, attributes);

            var result = await CommonOperationAsync<Player>(async () =>
            {
                return await _playerManager.CreateAsync(request);
            });
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<Player, PlayerResponse>(result)));
        }

        [Route("{id:int}/matchGroupId/{matchGroupId:int}/updateguestplayer")]
        [HttpPut]
        public Task<IActionResult> UpdateGuestPlayerAsync(int id, int matchGroupId, [FromBody] UpdatePlayerRequest request)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var attributes = new List<PermissionAttribute> {
                    new PermissionAttribute(nameof(PermissionEnum.UpdateUser), nameof(BooleanEnum.True))
                 };
                await _permissionChecker.HasPermissionAsync(User, matchGroupId, attributes);

                if (!ModelState.IsValid)
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

                var result = await _playerManager.UpdateAsync(id, request);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<Player, PlayerResponse>(result)));
            });
        }

        [Route("{id:int}/update")]
        [HttpPut]
        public Task<IActionResult> UpdateAsync(int id, int matchGroupId, [FromBody] UpdatePlayerRequest request)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var loggedUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var playerUser = await _playerManager.GetUserByIdAsync(id);

                if (loggedUserId != playerUser.Id) //Eğer giriş yapan kullanıcı, farklı kullanıcıya ait bilgileri güncellemek istiyorsa yetkisi kontrol ediliyor
                {
                    var attributes = new List<PermissionAttribute> {
                    new PermissionAttribute(nameof(PermissionEnum.UpdateUser), nameof(BooleanEnum.True))
                 };
                    await _permissionChecker.HasPermissionAsync(User, 0, attributes);
                }

                if (!ModelState.IsValid)
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

                var result = await _playerManager.UpdateAsync(id, request);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<Player, PlayerResponse>(result)));
            });
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(SpecialEnums.OnlyAdmin), nameof(BooleanEnum.True))]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _playerManager.DeleteAsync(id);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }        

        [Route("get/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await CommonOperationAsync<Player>(async () =>
            {
                return await _playerManager.GetByIdAsync(id);
            });
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<Player, PlayerResponse>(result)));
        }      

        [Route("getuser/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var result = await CommonOperationAsync<User>(async () =>
            {
                return await _playerManager.GetUserByIdAsync(id);
            });
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<User, UserResponse>(result)));
        }          

        [Route("getall/matchgroupid/{matchGroupId:int}")]
        [HttpGet]
        public async Task<IActionResult> GetAllByMatchGroupIdAsync(int matchGroupId)
        {
            var result = await CommonOperationAsync<IList<Player>>(async () =>
            {
                return await _playerManager.GetAllByMatchGroupIdAsync(matchGroupId);
            });

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<Player>, IList<PlayerResponse>>(result), result.Count));
        }        

        [Route("getwithbasketballstats/id/{id:int}/matchGroupId/{matchGroupId:int}")]
        [HttpGet]
        public Task<IActionResult> GetWithBasketballStatsById(int id, int matchGroupId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await _playerManager.GetByIdWithBasketballStatsAsync(id, matchGroupId);
                var userDetailResponse = Mapper.Map<UserDetailWithBasketballStat, UserDetailWithBasketballStatResponse>(result);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(userDetailResponse));
            });
        }      

        [Route("getwithfootballstats/id/{id:int}/matchGroupId/{matchGroupId:int}")]
        [HttpGet]
        public Task<IActionResult> GetWithFootballStatsById(int id, int matchGroupId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await _playerManager.GetByIdWithFootballStatsAsync(id, matchGroupId);
                var userDetailResponse = Mapper.Map<UserDetailWithFootballStat, UserDetailWithFootballStatResponse>(result);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(userDetailResponse));
            });
        }           
    }
}