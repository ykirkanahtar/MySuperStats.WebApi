using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Identity.Controllers;
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
    [Route(ApiConstants.DefaultRoute + "MatchGroupUser")]
    public class MatchGroupUserController : BaseControllerWithCrdAuthorization<MatchGroupUser, MatchGroupUserRequest, MatchGroupUserResponse, IMatchGroupUserManager, int>
    {

        public MatchGroupUserController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IMatchGroupUserManager manager)
             : base(localizationService, logger, mapper, manager)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(PermissionEnum.CreateMatchGroupUser), nameof(BooleanEnum.True))]
        public async Task<IActionResult> Create([FromBody]MatchGroupUserRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(PermissionEnum.DeleteMatchGroupUser), nameof(BooleanEnum.True))]
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

        [Route("getalluser/matchgroup/{matchGroupId:int}")]
        [HttpGet]
        public Task<IActionResult> GetUsersByMatchGroupId(int matchGroupId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetUsersByMatchGroupIdAsync(matchGroupId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<User>, IList<UserResponse>>(result)));
            });
        }

        [Route("getallmatchgroup/user/{userId:int}")]
        [HttpGet]
        public Task<IActionResult> GetMatchGroupsByUserId(int userId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetMatchGroupsByUserIdAsync(userId);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<MatchGroup>, IList<MatchGroupResponse>>(result)));
            });
        }
    }
}