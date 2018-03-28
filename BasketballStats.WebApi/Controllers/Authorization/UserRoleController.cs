using AutoMapper;
using BasketballStats.WebApi.Authorization;
using BasketballStats.WebApi.Authorization.Business.Contracts;
using BasketballStats.WebApi.Authorization.Enums;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Authorization.Response;
using BasketballStats.WebApi.Resources;
using BasketballStats.WebApi.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Controllers.Authorization
{
    [Route(ApiConstants.AdminRoute + "userrole")]
    public class UserRoleController : Controller
    {
        private readonly IUserRoleManager _userRoleManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<UserRoleController> _logger;
        private readonly IMapper _mapper;

        public UserRoleController(IUserRoleManager userRoleManager, ILocalizationService localizationService, ILogger<UserRoleController> logger, IMapper mapper)
        {
            _userRoleManager = userRoleManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("addusertorole")]
        [HttpPost]
        [Permission(Entity.UserRole, Crud.Create)]
        public async Task<IActionResult> AddUserTorole([FromBody] UserRoleRequest request)
        {
            var result = await _userRoleManager.AddUserToRoleAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(result));
        }

        [Route("{id:int}/removeuserfromrole")]
        [HttpPut]
        [Permission(Entity.UserRole, Crud.Delete)]
        public async Task<IActionResult> RemoveUserFromRole(int id)
        {
            var result = await _userRoleManager.RemoveUserFromRoleAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(result));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(Entity.UserRole, Crud.Select)]
        public async Task<IActionResult> GetBydId(int id)
        {
            var result = await _userRoleManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<UserRole, UserRoleResponse>(result)));
        }

        [Route("get/users/roleid/{roleid:int}")]
        [HttpGet]
        [Permission(Entity.UserRole, Crud.Select)]
        public async Task<IActionResult> GetUsersByRoleId(int roleId)
        {
            var result = await _userRoleManager.GetUsersByRoleIdAsync(roleId);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<User>, List<UserResponse>>(result.EntityList),
                result.Count));
        }

        [Route("get/role/userid/{userid:int}")]
        [HttpGet]
        [Permission(Entity.UserRole, Crud.Select)]
        public async Task<IActionResult> GetRolesByUserId(int userId)
        {
            var result = await _userRoleManager.GetRolesByUserIdAsync(userId);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<Role>, List<RoleResponse>>(result.EntityList),
                result.Count));
        }

    }
}
