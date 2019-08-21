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
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomFramework.WebApiUtils.Identity.Controllers;

namespace MySuperStats.WebApi.Controllers
{
    [Route(ApiConstants.DefaultRoute + "basketballstat")]
    public class BasketballStatController : BaseControllerWithCrudAuthorization<BasketballStat, BasketballStatRequest, BasketballStatRequest, BasketballStatResponse, IBasketballStatManager, int>
    {
        public BasketballStatController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IBasketballStatManager manager)
            : base(localizationService, logger, mapper, manager)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(PermissionEnum.CreateBasketballStat), nameof(BooleanEnum.True))]
        public async Task<IActionResult> Create([FromBody] BasketballStatRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("createwithmultistats")]
        [HttpPost]
        [Permission(nameof(PermissionEnum.CreateBasketballStat), nameof(BooleanEnum.True))]
        public Task<IActionResult> CreateMultiStats([FromBody] MatchRequest request)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.CreateMultiStats(request);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(result));
            });
        }        

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(PermissionEnum.UpdateBasketballStat), nameof(BooleanEnum.True))]
        public Task<IActionResult> UpdateName(int id, [FromBody] BasketballStatRequest request)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.UpdateAsync(id, request);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<BasketballStat, BasketballStatResponse>(result)));
            });
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(PermissionEnum.DeleteBasketballStat), nameof(BooleanEnum.True))]
        public async Task<IActionResult> Delete(int id)
        {
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