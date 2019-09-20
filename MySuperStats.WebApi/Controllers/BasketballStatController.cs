using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.ApplicationSettings;
using MySuperStats.WebApi.Business;
using MySuperStats.WebApi.Models;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Contracts.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomFramework.WebApiUtils.Identity.Controllers;
using MySuperStats.Contracts.Enums;
using System;
using CustomFramework.WebApiUtils.Utils.Exceptions;

namespace MySuperStats.WebApi.Controllers
{
    [Route(ApiConstants.DefaultRoute + "basketballstat")]
    public class BasketballStatController : BaseControllerWithCrudAuthorization<BasketballStat, BasketballStatRequest, BasketballStatRequest, BasketballStatResponse, IBasketballStatManager, int>
    {
        private readonly IPermissionChecker _permissionChecker;

        public BasketballStatController(IPermissionChecker permissionChecker, ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IBasketballStatManager manager)
            : base(localizationService, logger, mapper, manager)
        {
            _permissionChecker = permissionChecker;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BasketballStatRequest request)
        {
            var attributes = new List<PermissionAttribute> {
                    new PermissionAttribute(nameof(PermissionEnum.CreateBasketballStat), nameof(BooleanEnum.True))
                 };
            await _permissionChecker.HasPermissionByMatchIdAsync(User, attributes, request.MatchId);

            return await BaseCreateAsync(request);
        }

        [Route("createwithmultistats")]
        [HttpPost]
        public Task<IActionResult> CreateMultiStats([FromBody] MatchRequest request)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var attributes = new List<PermissionAttribute> {
                    new PermissionAttribute(nameof(PermissionEnum.CreateBasketballStat), nameof(BooleanEnum.True))
                 };
                await _permissionChecker.HasPermissionAsync(User, request.MatchGroupId, attributes);

                if (!ModelState.IsValid)
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

                var result = await Manager.CreateMultiStats(request);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(result));
            });
        }

        [Route("{id:int}/update")]
        [HttpPut]
        public Task<IActionResult> Update(int id, [FromBody] BasketballStatRequest request)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var attributes = new List<PermissionAttribute> {
                    new PermissionAttribute(nameof(PermissionEnum.UpdateBasketballStat), nameof(BooleanEnum.True))
                 };
                await _permissionChecker.HasPermissionByMatchIdAsync(User, attributes, request.MatchId);

                if (!ModelState.IsValid)
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

                var result = await Manager.UpdateAsync(id, request);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<BasketballStat, BasketballStatResponse>(result)));
            });
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var attributes = new List<PermissionAttribute> {
                    new PermissionAttribute(nameof(PermissionEnum.DeleteBasketballStat), nameof(BooleanEnum.True))
                 };
            await _permissionChecker.HasPermissionByMatchIdAsync(User, attributes, id);

            return await BaseDeleteAsync(id);
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetByIdAsync(id);
        }

        [Route("getall/matchid/{matchId:int}")]
        [HttpGet]
        public Task<IActionResult> GetAllByMatchId(int matchId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllByMatchIdAsync(matchId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<BasketballStat>, IList<BasketballStatResponse>>(result)));
            });
        }

        [Route("getall/matchgroupid/{matchGroupId:int}/userid/{userId:int}")]
        [HttpGet]
        public Task<IActionResult> GetAllByUserId(int matchGroupId, int userId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllByMatchGroupIdAndUserIdAsync(matchGroupId, userId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<BasketballStat>, IList<BasketballStatResponse>>(result)));
            });
        }

        [Route("getall/matchgroupid/{matchGroupId:int}")]
        [HttpGet]
        public Task<IActionResult> GetAllByMatchGroupId(int matchGroupId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllByMatchGroupIdAsync(matchGroupId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<BasketballStat>, IList<BasketballStatResponse>>(result)));
            });
        }

        [Route("gettopstats/matchgroupid/{matchGroupId:int}")]
        [HttpGet]
        public Task<IActionResult> GetTopStats(int matchGroupId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetTopStats(matchGroupId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(result));
            });
        }
    }
}