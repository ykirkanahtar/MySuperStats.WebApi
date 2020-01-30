using AutoMapper;
using MySuperStats.WebApi.ApplicationSettings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySuperStats.WebApi.Models;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using System.Threading.Tasks;
using MySuperStats.WebApi.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using CustomFramework.BaseWebApi.Identity.Controllers;
using CustomFramework.BaseWebApi.Resources;
using CustomFramework.BaseWebApi.Authorization.Attributes;
using CustomFramework.BaseWebApi.Authorization.Enums;
using CustomFramework.BaseWebApi.Identity.Business;

namespace MySuperStats.WebApi.Controllers.Authorization
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route(ApiConstants.DefaultRoute + nameof(Role))]
    public class RoleController : BaseRoleController<Role, RoleRequest, RoleResponse>
    {
        public RoleController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, ICustomRoleManager<Role> roleManager)
            : base(localizationService, logger, mapper, roleManager)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(SpecialEnums.OnlyAdmin), nameof(BooleanEnum.True))]
        public async Task<IActionResult> CreateAsync([FromBody] RoleRequest request)
        {
            return await base.CreateAsync(request);
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(SpecialEnums.OnlyAdmin), nameof(BooleanEnum.True))]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] RoleRequest request)
        {
            return await base.UpdateAsync(id, request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(SpecialEnums.OnlyAdmin), nameof(BooleanEnum.True))]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }

        [Route("get/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetRoleByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        [Route("get/name/{name}")]
        [HttpGet]
        public async Task<IActionResult> GetRoleByNameAsync(string name)
        {
            return await base.GetByNameAsync(name);
        }

        [Route("getall")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var roles = await _roleManager.GetAllAsync();
            return Ok(roles.Select(p => p.Name).ToList());
        }

    }
}
