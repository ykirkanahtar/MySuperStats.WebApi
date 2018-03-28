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
    [Route(ApiConstants.AdminRoute + "roleentityclaim")]
    public class RoleEntityClaimController : Controller
    {
        private readonly IRoleEntityClaimManager _roleEntityClaimManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<RoleEntityClaimController> _logger;
        private readonly IMapper _mapper;

        public RoleEntityClaimController(IRoleEntityClaimManager roleEntityClaimManager, ILocalizationService localizationService, ILogger<RoleEntityClaimController> logger, IMapper mapper)
        {
            _roleEntityClaimManager = roleEntityClaimManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        [Permission(Entity.RoleEntityClaim, Crud.Create)]
        public async Task<IActionResult> Create([FromBody] RoleEntityClaimRequest request)
        {
            var result = await _roleEntityClaimManager.CreateAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<RoleEntityClaim, RoleEntityClaimResponse>(result)));
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(Entity.RoleEntityClaim, Crud.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] EntityClaimRequest request)
        {
            var result = await _roleEntityClaimManager.UpdateAsync(id, request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<RoleEntityClaim, RoleEntityClaimResponse>(result)));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(Entity.RoleEntityClaim, Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleEntityClaimManager.DeleteAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(true));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(Entity.RoleEntityClaim, Crud.Select)]
        public async Task<IActionResult> GetBydId(int id)
        {
            var result = await _roleEntityClaimManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<RoleEntityClaim, RoleEntityClaimResponse>(result)));
        }

        [Route("getall/entity/{entity}")]
        [HttpGet]
        [Permission(Entity.RoleEntityClaim, Crud.Select)]
        public async Task<IActionResult> GetAllByEntity(Entity entity)
        {
            var result = await _roleEntityClaimManager.GetAllByEntityAsync(entity);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<RoleEntityClaim>, List<RoleEntityClaimResponse>>(result.EntityList),
                result.Count));
        }

        [Route("getall/roleid/{roleid:int}")]
        [HttpGet]
        [Permission(Entity.RoleEntityClaim, Crud.Select)]
        public async Task<IActionResult> GetAllByRoleId(int roleId)
        {
            var result = await _roleEntityClaimManager.GetAllByRoleIdAsync(roleId);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<RoleEntityClaim>, List<RoleEntityClaimResponse>>(result.EntityList),
                result.Count));
        }
    }
}
