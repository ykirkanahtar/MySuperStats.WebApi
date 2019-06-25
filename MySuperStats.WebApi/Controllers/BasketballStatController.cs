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
        [Permission(nameof(WebApiEntities.BasketballStat), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] BasketballStatRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(WebApiEntities.BasketballStat), Crud.Update)]
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
        [Permission(nameof(WebApiEntities.BasketballStat), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDeleteAsync(id);
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetByIdAsync(id);
        }

        [Route("getall/matchid/{matchId:int}")]
        [HttpGet]
        [AllowAnonymous]
        public Task<IActionResult> GetAllByMatchId(int matchId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllByMatchIdAsync(matchId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<BasketballStat>, IList<BasketballStatResponse>>(result)));
            });
        }

        [Route("getall/userid/{userId:int}")]
        [HttpGet]
        [AllowAnonymous]
        public Task<IActionResult> GetAllByUserId(int userId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllByUserIdAsync(userId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<BasketballStat>, IList<BasketballStatResponse>>(result)));
            });
        }

        [Route("getall")]
        [HttpGet]
        [AllowAnonymous]
        public Task<IActionResult> GetAll()
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllAsync();

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<BasketballStat>, IList<BasketballStatResponse>>(result)));
            });
        }

        [Route("gettopstats")]
        [HttpGet]
        [AllowAnonymous]
        public Task<IActionResult> GetTopStats()
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetTopStats();

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(result));
            });
        }
    }
}