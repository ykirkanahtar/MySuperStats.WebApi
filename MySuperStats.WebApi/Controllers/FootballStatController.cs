using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Controllers;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Business;
using MySuperStats.WebApi.Enums;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Controllers
{
    public class FootballStatController : BaseControllerWithCrudAuthorization<FootballStat, FootballStatRequest, FootballStatRequest, FootballStatResponse, IFootballStatManager, int>
    {
        public FootballStatController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IFootballStatManager manager)
            : base(localizationService, logger, mapper, manager)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(WebApiEntities.FootballStat), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] FootballStatRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(WebApiEntities.FootballStat), Crud.Update)]
        public Task<IActionResult> UpdateName(int id, [FromBody] FootballStatRequest request)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.UpdateAsync(id, request);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<FootballStat, FootballStatResponse>(result)));
            });
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(WebApiEntities.FootballStat), Crud.Delete)]
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
                    Mapper.Map<IEnumerable<FootballStat>, IEnumerable<FootballStatResponse>>(result.ResultList), result.Count));
            });
        }

        [Route("getall/playerid/{playerId:int}")]
        [HttpGet]
        [AllowAnonymous]
        public Task<IActionResult> GetAllByPlayerId(int playerId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllByPlayerIdAsync(playerId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IEnumerable<FootballStat>, IEnumerable<FootballStatResponse>>(result.ResultList), result.Count));
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
                    Mapper.Map<IEnumerable<FootballStat>, IEnumerable<FootballStatResponse>>(result.ResultList), result.Count));
            });
        }

    }
}