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
    [Route(ApiConstants.AdminRoute + "role")]
    public class RoleController : Controller
    {
        private readonly IRoleManager _roleManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<RoleController> _logger;
        private readonly IMapper _mapper;

        public RoleController(IRoleManager roleManager, ILocalizationService localizationService, ILogger<RoleController> logger, IMapper mapper)
        {
            _roleManager = roleManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        [Permission(Entity.Role, Crud.Create)]
        public async Task<IActionResult> Create([FromBody] RoleRequest request)
        {
            var result = await _roleManager.CreateAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Role, RoleResponse>(result)));
        }

        [Route("{id:int}/update/rolename")]
        [HttpPut]
        [Permission(Entity.Role, Crud.Update)]
        public async Task<IActionResult> UpdateRoleName(int id, [FromBody] RoleRequest request)
        {
            var result = await _roleManager.UpdateAsync(id, request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Role, RoleResponse>(result)));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(Entity.Role, Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleManager.DeleteAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(true));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(Entity.Role, Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _roleManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Role, RoleResponse>(result)));
        }

        [Route("get/rolename/{rolename}")]
        [HttpGet]
        [Permission(Entity.Role, Crud.Select)]
        public async Task<IActionResult> GetByRoleName(string roleName)
        {
            var result = await _roleManager.GetByNameAsync(roleName);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Role, RoleResponse>(result)));
        }


        [Route("getall")]
        [HttpGet]
        [Permission(Entity.Role, Crud.Select)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _roleManager.GetAllAsync();
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<Role>, List<RoleResponse>>(result.EntityList),
                result.Count));
        }


    }
}
