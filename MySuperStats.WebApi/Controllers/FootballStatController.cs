using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Identity.Controllers;
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
        [Permission(nameof(PermissionEnum.CreateFootballStat), nameof(BooleanEnum.True))]
        public async Task<IActionResult> Create([FromBody] FootballStatRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(PermissionEnum.UpdateFootballStat), nameof(BooleanEnum.True))]
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
        [Permission(nameof(PermissionEnum.DeleteFootballStat), nameof(BooleanEnum.True))]
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
                    Mapper.Map<IList<FootballStat>, IList<FootballStatResponse>>(result)));
            });
        }

        [Route("getall/userid/{userId:int}")]
        [HttpGet]
        public Task<IActionResult> GetAllByUserId(int userId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllByUserIdAsync(userId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<FootballStat>, IList<FootballStatResponse>>(result)));
            });
        }

        [Route("getall")]
        [HttpGet]
        public Task<IActionResult> GetAll()
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllAsync();

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<FootballStat>, IList<FootballStatResponse>>(result)));
            });
        }

    }
}