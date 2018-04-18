using AutoMapper;
using BasketballStats.WebApi.ApplicationSettings;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Controllers;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BasketballStats.WebApi.Controllers.Authorization
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route(ApiConstants.AdminRoute + "role")]
    public class RoleController : BaseRoleController
    {
        public RoleController(IRoleManager roleManager, ILocalizationService localizationService, ILogger<RoleController> logger, IMapper mapper)
        : base(roleManager, localizationService, logger, mapper)
        {

        }
    }
}
