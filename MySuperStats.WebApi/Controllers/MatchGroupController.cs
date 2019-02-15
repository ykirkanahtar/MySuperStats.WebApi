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
using MySuperStats.WebApi.ApplicationSettings;
using MySuperStats.WebApi.Business;
using MySuperStats.WebApi.Enums;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Controllers
{
    [Route(ApiConstants.DefaultRoute + "matchgroup")]    
    public class MatchGroupController : BaseControllerWithCrudAuthorization<MatchGroup, MatchGroupRequest, MatchGroupRequest, MatchGroupResponse, IMatchGroupManager, int>
    {
        public MatchGroupController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IMatchGroupManager manager)
         : base(localizationService, logger, mapper, manager)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(WebApiEntities.MatchGroup), Crud.Create)]
        public async Task<IActionResult> Create([FromBody]MatchGroupRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(WebApiEntities.MatchGroup), Crud.Update)]
        public async Task<IActionResult> Update(int id, [FromBody]MatchGroupRequest request)
        {
            return await BaseUpdateAsync(id, request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(WebApiEntities.MatchGroup), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDeleteAsync(id);
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(WebApiEntities.MatchGroup), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetByIdAsync(id);
        }

        [Route("get/groupname/{groupName}")]
        [HttpGet]
        [Permission(nameof(WebApiEntities.MatchGroup), Crud.Select)]
        public Task<IActionResult> GetByGroupName(string groupName)
        {
            return CommonOperationAsync<IActionResult>(async()=>
            {
                var result = await Manager.GetByGroupNameAsync(groupName);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<MatchGroup, MatchGroupResponse>(result)));
            });
        }
    }
}