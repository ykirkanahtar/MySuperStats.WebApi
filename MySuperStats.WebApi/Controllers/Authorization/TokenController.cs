using AutoMapper;
using MySuperStats.WebApi.ApplicationSettings;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Controllers;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MySuperStats.WebApi.Controllers.Authorization
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route(ApiConstants.DefaultRoute + "token")]
    public class TokenController : BaseTokenController
    {
        public TokenController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IApplicationManager applicationManager, IApplicationUserManager applicationUserManager, IClientApplicationManager clientApplicationManager, IUserManager userManager, IAppSettings appSettings)
            : base(localizationService, logger, mapper, applicationManager, applicationUserManager, clientApplicationManager, userManager, appSettings.Token)
        {

        }
    }
}