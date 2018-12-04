using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BasketballStats.Contracts.Requests;
using BasketballStats.Contracts.Responses;
using BasketballStats.WebApi.ApplicationSettings;
using BasketballStats.WebApi.Business;
using BasketballStats.WebApi.Enums;
using BasketballStats.WebApi.Models;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Controllers;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BasketballStats.WebApi.Controllers
{
    [Route(ApiConstants.DefaultRoute + "stat")]
    public class StatController : BaseControllerWithCrudAuthorization<Stat, StatRequest, StatRequest, StatResponse, IStatManager, int>
    {
        public StatController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IStatManager manager)
            : base(localizationService, logger, mapper, manager)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(WebApiEntities.Stat), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] StatRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(WebApiEntities.Stat), Crud.Update)]
        public Task<IActionResult> UpdateName(int id, [FromBody] StatRequest request)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.UpdateAsync(id, request);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<Stat, StatResponse>(result)));
            });
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(WebApiEntities.Stat), Crud.Delete)]
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

        [Route("getall/matchid/{matchid:int}")]
        [HttpGet]
        [AllowAnonymous]
        public Task<IActionResult> GetAllByMatchId(int matchId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllByMatchIdAsync(matchId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IEnumerable<Stat>, IEnumerable<StatResponse>>(result.ResultList), result.Count));
            });
        }

        [Route("getall/playerid/{playerid:int}")]
        [HttpGet]
        [AllowAnonymous]
        public Task<IActionResult> GetAllByPlayerId(int playerId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllByPlayerIdAsync(playerId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IEnumerable<Stat>, IEnumerable<StatResponse>>(result.ResultList), result.Count));
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
                    Mapper.Map<IEnumerable<Stat>, IEnumerable<StatResponse>>(result.ResultList), result.Count));
            });
        }
    }
}