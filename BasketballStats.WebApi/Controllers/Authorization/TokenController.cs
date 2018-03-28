﻿using BasketballStats.WebApi.Authorization;
using BasketballStats.WebApi.Authorization.Business.Contracts;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Authorization.Response;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Exceptions;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Resources;
using BasketballStats.WebApi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Controllers.Authorization
{
    [Route(ApiConstants.DefaultRoute + "token")]
    public class TokenController : Controller
    {
        private readonly IClientApplicationManager _clientApplicationManager;
        private readonly IUserManager _userManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<TokenController> _logger;

        public TokenController(IClientApplicationManager clientApplicationManager, IUserManager userManager, ILocalizationService localizationService, ILogger<TokenController> logger)
        {
            _clientApplicationManager = clientApplicationManager;
            _userManager = userManager;
            _localizationService = localizationService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException(ModelState.ModelStateToString());

            var clientApplication =
                await _clientApplicationManager.LoginAsync(login.ClientApplicationCode, login.ClientApplicationPassword);

            var user = await _userManager.LoginAsync(login.UserName, login.UserPassword);

            var apiRequest = new ApiRequest(user, clientApplication);

            var claims = new List<Claim>
            {
                new Claim(typeof(IApiRequest).Name, JsonConvert.SerializeObject(apiRequest)),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = ConfigHelper.GetConfigurationValue("Tokens:Key");
            var issuer = ConfigHelper.GetConfigurationValue("Tokens:Issuer");
            var audience = ConfigHelper.GetConfigurationValue("Tokens:Audience");
            var expireInMinutes = Convert.ToInt32(ConfigHelper.GetConfigurationValue("Tokens:ExpireInMinutes"));
            var token = JwtManager.GenerateToken(claims, key, issuer, audience, out var expireDateTime, expireInMinutes);

            var tokenResponse = new TokenResponse
            {
                Token = token,
                ExpireInMinutes = expireInMinutes,
                RequestUtcDateTime = DateTime.UtcNow,
                ExpireUtcDateTime = expireDateTime,
            };

            return Ok(new ApiResponse(_localizationService, _logger).Ok(tokenResponse));
        }
    }
}