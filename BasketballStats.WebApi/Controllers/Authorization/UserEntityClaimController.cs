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

    [Route(ApiConstants.AdminRoute + "userentityclaim")]
    public class UserEntityClaimController : BaseUserEntityClaimController
    {
        public UserEntityClaimController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IUserEntityClaimManager manager)
            : base(localizationService, logger, mapper, manager)
        {

        }
    }
}
