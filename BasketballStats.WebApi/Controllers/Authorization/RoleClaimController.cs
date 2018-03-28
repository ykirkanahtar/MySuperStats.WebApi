using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasketballStats.WebApi.Authorization;
using BasketballStats.WebApi.Authorization.Business.Contracts;
using BasketballStats.WebApi.Authorization.Enums;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Authorization.Response;
using BasketballStats.WebApi.Resources;
using BasketballStats.WebApi.Utils;

namespace BasketballStats.WebApi.Controllers.Authorization
{
    [Route(ApiConstants.AdminRoute + "roleclaim")]
    public class RoleClaimController : Controller
    {
        private readonly IRoleClaimManager _roleClaimManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<RoleClaimController> _logger;
        private readonly IMapper _mapper;

        public RoleClaimController(IRoleClaimManager roleClaimManager, ILocalizationService localizationService, ILogger<RoleClaimController> logger, IMapper mapper)
        {
            _roleClaimManager = roleClaimManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("addroletoclaim")]
        [HttpPost]
        [Permission(Entity.RoleClaim, Crud.Create)]
        public async Task<IActionResult> AddRoleToClaim([FromBody] RoleClaimRequest request)
        {
            var result = await _roleClaimManager.AddRoleToClaimAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(result));
        }

        [Route("{id:int}/removerolefromclaim")]
        [HttpPut]
        [Permission(Entity.RoleClaim, Crud.Delete)]
        public async Task<IActionResult> RemoveRoleFromClaim(int id)
        {
            var result = await _roleClaimManager.RemoveRoleFromClaimAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(result));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(Entity.RoleClaim, Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _roleClaimManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<RoleClaim, RoleClaimResponse>(result)));
        }

        [Route("get/roles/claimid/{id:int}")]
        [HttpGet]
        [Permission(Entity.RoleClaim, Crud.Select)]
        public async Task<IActionResult> GetRolesByClaimId(int claimId)
        {
            var result = await _roleClaimManager.GetRolesByClaimIdAsync(claimId);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<Role>, List<RoleResponse>>(result.EntityList),
                result.Count));
        }

        [Route("get/claim/roleid/{id:int}")]
        [HttpGet]
        [Permission(Entity.RoleClaim, Crud.Select)]
        public async Task<IActionResult> GetClaimsByRoleId(int roleId)
        {
            var result = await _roleClaimManager.GetClaimsByRoleIdAsync(roleId);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<Claim>, List<ClaimResponse>>(result.EntityList),
                result.Count));
        }

    }
}
