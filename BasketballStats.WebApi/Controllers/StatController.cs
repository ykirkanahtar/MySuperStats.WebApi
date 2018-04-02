using AutoMapper;
using BasketballStats.Contracts.Requests;
using BasketballStats.Contracts.Responses;
using BasketballStats.WebApi.Authorization;
using BasketballStats.WebApi.Authorization.Enums;
using BasketballStats.WebApi.Business.Contracts;
using BasketballStats.WebApi.Models;
using BasketballStats.WebApi.Resources;
using BasketballStats.WebApi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Controllers
{
    [Route(ApiConstants.DefaultRoute + "stat")]
    public class StatController : Controller
    {
        private readonly IStatManager _statManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<StatController> _logger;
        private readonly IMapper _mapper;

        public StatController(IStatManager statManager, ILocalizationService localizationService, ILogger<StatController> logger, IMapper mapper)
        {
            _statManager = statManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        [Permission(Entity.Stat, Crud.Create)]
        public async Task<IActionResult> Create([FromBody] StatRequest request)
        {
            var result = await _statManager.CreateAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Stat, StatResponse>(result)));
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(Entity.Stat, Crud.Update)]
        public async Task<IActionResult> UpdateName(int id, [FromBody] StatRequest request)
        {
            var result = await _statManager.UpdateAsync(id, request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Stat, StatResponse>(result)));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(Entity.Stat, Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            await _statManager.DeleteAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(true));
        }
        [Route("get/id/{id:int}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _statManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Stat, StatResponse>(result)));
        }

        [Route("getall/matchid/{matchid:int}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllByMatchId(int matchId)
        {
            var result = await _statManager.GetAllByMatchIdAsync(matchId);

            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<Stat>, List<StatResponse>>(result.EntityList), result.Count));
        }

        [Route("getall/playerid/{playerid:int}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllByPlayerId(int playerId)
        {
            var result = await _statManager.GetAllByPlayerIdAsync(playerId);

            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<Stat>, List<StatResponse>>(result.EntityList), result.Count));
        }
    }
}