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
    [Route(ApiConstants.AdminRoute + "roleclaim")]
    public class RoleClaimController : BaseRoleClaimController
    {
        public RoleClaimController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IRoleClaimManager manager)
            : base(localizationService, logger, mapper, manager)
        {

        }
    }
}
