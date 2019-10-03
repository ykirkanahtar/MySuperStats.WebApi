using AutoMapper;
using MySuperStats.WebApi.ApplicationSettings;
using CustomFramework.WebApiUtils.Contracts.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomFramework.WebApiUtils.Identity.Controllers;
using CustomFramework.WebApiUtils.Identity.Business;
using MySuperStats.WebApi.Models;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using System.Threading.Tasks;
using CustomFramework.Authorization.Attributes;
using MySuperStats.WebApi.Enums;
using CustomFramework.Authorization.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

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
