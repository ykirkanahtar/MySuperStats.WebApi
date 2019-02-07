﻿using AutoMapper;
using MySuperStats.WebApi.ApplicationSettings;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Controllers;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MySuperStats.WebApi.Controllers.Authorization
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route(ApiConstants.AdminRoute + "clientapplication")]
    public class ClientApplicationController : BaseClientApplicationController
    {
        public ClientApplicationController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IClientApplicationManager manager)
            : base(localizationService, logger, mapper, manager)
        {

        }
    }
}