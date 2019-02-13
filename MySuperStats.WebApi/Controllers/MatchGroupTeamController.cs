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
    public class MatchGroupTeamController : BaseControllerWithCrdAuthorization<MatchGroupTeam, MatchGroupTeamRequest, MatchGroupTeamResponse, IMatchGroupTeamManager, int>
    {

        public MatchGroupTeamController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IMatchGroupTeamManager manager)
             : base(localizationService, logger, mapper, manager)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(WebApiEntities.MatchGroupTeam), Crud.Create)]
        public async Task<IActionResult> Create([FromBody]MatchGroupTeamRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("delete/{id:int")]
        [HttpDelete]
        [Permission(nameof(WebApiEntities.MatchGroupTeam), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDeleteAsync(id);
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(WebApiEntities.MatchGroupTeam), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetByIdAsync(id);
        }

        [Route("getallteam/matchgroup/{matchGroupId:int}")]
        [HttpGet]
        [Permission(nameof(WebApiEntities.MatchGroupTeam), Crud.Select)]
        public Task<IActionResult> GetTeamsByMatchGroupId(int matchGroupId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetTeamsByMatchGroupIdAsync(matchGroupId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IEnumerable<Team>, IEnumerable<TeamResponse>>(result.ResultList), result.Count));
            });
        }

        [Route("getallmatchgroup/team/{teamId:int}")]
        [HttpGet]
        [Permission(nameof(WebApiEntities.MatchGroupTeam), Crud.Select)]
        public Task<IActionResult> GetMatchGroupsByTeamId(int teamId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetMatchGroupsByTeamIdAsync(teamId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IEnumerable<MatchGroup>, IEnumerable<MatchGroupResponse>>(result.ResultList), result.Count));
            });
        }


    }
}