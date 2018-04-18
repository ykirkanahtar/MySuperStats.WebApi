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

    [Route(ApiConstants.AdminRoute + "userrole")]
    public class UserRoleController : BaseUserRoleController
    {

        public UserRoleController(IUserRoleManager userRoleManager, ILocalizationService localizationService, ILogger<UserRoleController> logger, IMapper mapper)
        : base(userRoleManager, localizationService, logger, mapper)
        {

        }
    }
}
