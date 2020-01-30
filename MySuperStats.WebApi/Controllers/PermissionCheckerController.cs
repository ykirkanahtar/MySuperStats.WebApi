using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MySuperStats.WebApi.ApplicationSettings;
using MySuperStats.WebApi.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using MySuperStats.Contracts.Enums;
using CustomFramework.BaseWebApi.Utils.Controllers;
using CustomFramework.BaseWebApi.Resources;
using CustomFramework.BaseWebApi.Utils.Contracts;

namespace MySuperStats.WebApi.Controllers
{
    [Route(ApiConstants.DefaultRoute + "PermissionChecker")]
    public class PermissionCheckerController : BaseController
    {
        private readonly IPermissionChecker _permissionChecker;
        public PermissionCheckerController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IPermissionChecker permissionChecker)
            : base(localizationService, logger, mapper)
        {
            _permissionChecker = permissionChecker;
        }

        [Route("haspermission/userId/{userId:int}/matchGroupId/{matchGroupId:int}")]
        [HttpGet]
        public Task<IActionResult> HasPermissionAsync([FromQuery(Name="permissions")] string[] permissions, int userId, int matchGroupId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var permissionEnums = new List<PermissionEnum>();
                foreach(var permission in permissions)
                {
                    permissionEnums.Add((PermissionEnum)Enum.Parse(typeof(PermissionEnum), permission));
                }

                var result = await _permissionChecker.HasPermissionAsyncByUserIdAndMatchGroupIdAsync(userId, matchGroupId, permissionEnums);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok((result)));
            });
        }
    }
}