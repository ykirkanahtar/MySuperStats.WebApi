using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Controllers;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Business;
using MySuperStats.WebApi.Enums;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Controllers
{
    public class MatchGroupPlayerController : BaseControllerWithCrdAuthorization<MatchGroupPlayer, MatchGroupPlayerRequest, MatchGroupPlayerResponse, IMatchGroupPlayerManager, int>
    {                                         

        public MatchGroupPlayerController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IMatchGroupPlayerManager manager)
             : base(localizationService, logger, mapper, manager)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(WebApiEntities.MatchGroupPlayer), Crud.Create)]
        public async Task<IActionResult> Create([FromBody]MatchGroupPlayerRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("delete/{id:int")]
        [HttpDelete]
        [Permission(nameof(WebApiEntities.MatchGroupPlayer), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDeleteAsync(id);
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(WebApiEntities.MatchGroupPlayer), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetByIdAsync(id);
        }

        [Route("getallplayer/matchgroup/{matchGroupId:int}")]
        [HttpGet]
        [Permission(nameof(WebApiEntities.MatchGroupPlayer), Crud.Select)]
        public Task<IActionResult> GetPlayersByMatchGroupId(int matchGroupId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetPlayersByMatchGroupIdAsync(matchGroupId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IEnumerable<Player>, IEnumerable<PlayerResponse>>(result.ResultList), result.Count));
            });
        }

        [Route("getallmatchgroup/player/{playerId:int}")]
        [HttpGet]
        [Permission(nameof(WebApiEntities.MatchGroupPlayer), Crud.Select)]
        public Task<IActionResult> GetMatchGroupsByPlayerId(int playerId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetMatchGroupsByPlayerIdAsync(playerId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IEnumerable<MatchGroup>, IEnumerable<MatchGroupResponse>>(result.ResultList), result.Count));
            });
        }
    }
}