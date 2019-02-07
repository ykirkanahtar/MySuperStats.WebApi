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
using CustomFramework.WebApiUtils.Authorization.Controllers;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MySuperStats.WebApi.Controllers
{
    [Route(ApiConstants.DefaultRoute + "player")]
    public class PlayerController : BaseControllerWithCrudAuthorization<Player, PlayerRequest, PlayerRequest, PlayerResponse, IPlayerManager, int>
    {
        public PlayerController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IPlayerManager manager)
            : base(localizationService, logger, mapper, manager)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(WebApiEntities.Player), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] PlayerRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(WebApiEntities.Player), Crud.Update)]
        public Task<IActionResult> UpdateName(int id, [FromBody] PlayerRequest request)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.UpdateAsync(id, request);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<Player, PlayerResponse>(result)));
            });
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(WebApiEntities.Player), Crud.Delete)]
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

        [Route("getwithstats/id/{id:int}")]
        [HttpGet]
        [AllowAnonymous]
        public Task<IActionResult> GetWithStatsById(int id)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetWithStats(id);
                var playerDetailResponse = Mapper.Map<Player, PlayerDetailResponse>(result);
                playerDetailResponse.SetFields();
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(playerDetailResponse));
            });
        }

        [Route("getall")]
        [HttpGet]
        [AllowAnonymous]
        public Task<IActionResult> GetAll(int skip, int take)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllAsync();

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IEnumerable<Player>, IEnumerable<PlayerResponse>>(result.ResultList), result.Count));
            });
        }
    }
}