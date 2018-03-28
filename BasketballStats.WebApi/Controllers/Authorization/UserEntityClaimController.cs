﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasketballStats.WebApi.Authorization;
using BasketballStats.WebApi.Authorization.Business.Contracts;
using BasketballStats.WebApi.Authorization.Enums;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Authorization.Response;
using BasketballStats.WebApi.Resources;
using BasketballStats.WebApi.Utils;

namespace BasketballStats.WebApi.Controllers.Authorization
{
    [Route(ApiConstants.AdminRoute + "userentityclaim")]
    public class UserEntityClaimController : Controller
    {
        private readonly IUserEntityClaimManager _userEntityClaimManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<UserEntityClaimController> _logger;
        private readonly IMapper _mapper;

        public UserEntityClaimController(IUserEntityClaimManager userEntityClaimManager, ILocalizationService localizationService, ILogger<UserEntityClaimController> logger, IMapper mapper)
        {
            _userEntityClaimManager = userEntityClaimManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        [Permission(Entity.UserEntityClaim, Crud.Create)]
        public async Task<IActionResult> Create([FromBody] UserEntityClaimRequest request)
        {
            var result = await _userEntityClaimManager.CreateAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<UserEntityClaim, UserEntityClaimResponse>(result)));
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(Entity.UserEntityClaim, Crud.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] EntityClaimRequest request)
        {
            var result = await _userEntityClaimManager.UpdateAsync(id, request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<UserEntityClaim, UserEntityClaimResponse>(result)));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(Entity.UserEntityClaim, Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            await _userEntityClaimManager.DeleteAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(true));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(Entity.UserEntityClaim, Crud.Select)]
        public async Task<IActionResult> GetBydId(int id)
        {
            var result = await _userEntityClaimManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<UserEntityClaim, UserEntityClaimResponse>(result)));
        }

        [Route("getall/entity/{entity}")]
        [HttpGet]
        [Permission(Entity.UserEntityClaim, Crud.Select)]
        public async Task<IActionResult> GetAllByEntity(Entity entity)
        {
            var result = await _userEntityClaimManager.GetAllByEntityAsync(entity);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<UserEntityClaim>, List<UserEntityClaimResponse>>(result.EntityList),
                result.Count));
        }

        [Route("getall/Userid/{Userid:int}")]
        [HttpGet]
        [Permission(Entity.UserEntityClaim, Crud.Select)]
        public async Task<IActionResult> GetAllByUserId(int userId)
        {
            var result = await _userEntityClaimManager.GetAllByUserIdAsync(userId);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<UserEntityClaim>, List<UserEntityClaimResponse>>(result.EntityList),
                result.Count));
        }
    }
}
