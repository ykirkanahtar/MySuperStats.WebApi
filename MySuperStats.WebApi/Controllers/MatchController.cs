using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.ApplicationSettings;
using MySuperStats.WebApi.Business;
using MySuperStats.WebApi.Enums;
using MySuperStats.WebApi.Models;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Identity.Controllers;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Enums;

namespace MySuperStats.WebApi.Controllers
{
    [Route(ApiConstants.DefaultRoute + "match")]
    public class MatchController : BaseControllerWithCrudAuthorization<Match, MatchRequest, MatchRequest, MatchResponse, IMatchManager, int>
    {
        private readonly IPermissionChecker _permissionChecker;

        public MatchController(IPermissionChecker permissionChecker, ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IMatchManager manager)
            : base(localizationService, logger, mapper, manager)
        {
            _permissionChecker = permissionChecker;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MatchRequest request)
        {
            var attributes = new List<PermissionAttribute> {
                new PermissionAttribute(nameof(PermissionEnum.CreateMatch), nameof(BooleanEnum.True))
            };
            await _permissionChecker.HasPermissionAsync(User, request.MatchGroupId, attributes);

            return await BaseCreateAsync(request);
        }

        [Route("{id:int}/update")]
        [HttpPut]
        public Task<IActionResult> UpdateName(int id, [FromBody] MatchRequest request)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var attributes = new List<PermissionAttribute> {
                    new PermissionAttribute(nameof(PermissionEnum.UpdateMatch), nameof(BooleanEnum.True))
                 };
                await _permissionChecker.HasPermissionAsync(User, request.MatchGroupId, attributes);

                var result = await Manager.UpdateAsync(id, request);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<Match, MatchResponse>(result)));
            });
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(PermissionEnum.DeleteMatch), nameof(BooleanEnum.True))]
        public async Task<IActionResult> Delete(int id)
        {
            var attributes = new List<PermissionAttribute> {
                    new PermissionAttribute(nameof(PermissionEnum.DeleteMatch), nameof(BooleanEnum.True))
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

        [Route("getall/matchgroupid/{matchGroupId:int}")]
        [HttpGet]
        public Task<IActionResult> GetAll(int matchGroupId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllByMatchGroupIdAsync(matchGroupId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<Match>, IList<MatchResponse>>(result)));
            });
        }

        [Route("getallformainscreen/matchgroupid/{matchGroupId:int}")]
        [HttpGet]
        public Task<IActionResult> GetAllForMainScreen(int matchGroupId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var attributes = new List<PermissionAttribute> {
                    new PermissionAttribute(nameof(PermissionEnum.CreateMatch), nameof(BooleanEnum.True))
                 };
                await _permissionChecker.HasPermissionAsync(User, matchGroupId, attributes);

                var result = await Manager.GetMatchForMainScreen(matchGroupId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                                   Mapper.Map<IList<Match>, IList<MatchResponse>>(result)));
            });
        }

        [Route("getmatchdetailbasketballstats/id/{id:int}")]
        [HttpGet]
        public Task<IActionResult> GetMatchDetailBasketballStats(int id)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetMatchDetailBasketballStats(id);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<Match, MatchResponse>(result)));
            });
        }

    }
}