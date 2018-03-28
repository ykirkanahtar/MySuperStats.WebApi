using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BasketballStats.WebApi.Authorization;
using BasketballStats.WebApi.Authorization.Enums;
using BasketballStats.WebApi.Business.Contracts;
using BasketballStats.WebApi.Models;
using BasketballStats.WebApi.RequestModels;
using BasketballStats.WebApi.Resources;
using BasketballStats.WebApi.ResponseModels;
using BasketballStats.WebApi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [Route("get/matchid/{matchid:int}/playerid/{playerid:int}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetByMatchIdAndPlayerId(int matchId, int playerId)
        {
            var result = await _statManager.GetByMatchIdAndPlayerIdAsync(matchId, playerId);

            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Stat, StatResponse>(result)));
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

        [Route("getall/playerid/{playerid:int}/startdate/{startdate}/enddate/{enddate}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllByPlayerIdAndDate(int playerId, DateTime startDateTime, DateTime endDateTime)
        {
            var result = await _statManager.GetAllByPlayerIdAndDateAsync(playerId, startDateTime, endDateTime);

            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<Stat>, List<StatResponse>>(result.EntityList), result.Count));
        }

        [Route("getallplayer/matchid/{matchid:int}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPlayerByMatchId(int matchId)
        {
            var result = await _statManager.GetAllPlayerByMatchIdAsync(matchId);

            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<Player>, List<PlayerResponse>>(result.EntityList), result.Count));
        }

        [Route("getallplayer/startdate/{startdate}/enddate/{enddate}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPlayerByDate(DateTime startDateTime, DateTime endDateTime)
        {
            var result = await _statManager.GetAllPlayerByDateAsync(startDateTime, endDateTime);

            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<Player>, List<PlayerResponse>>(result.EntityList), result.Count));
        }

        [Route("getallmatch/playerid/{playerid:int}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllMatchByPlayerId(int playerId)
        {
            var result = await _statManager.GetAllMatchByPlayerIdAsync(playerId);

            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<Match>, List<MatchResponse>>(result.EntityList), result.Count));
        }

        [Route("getallmatch/playerid/{playerid:int}/startdate/{startdate}/enddate/{enddate}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllMatchByPlayerIdAndDate(int playerId, DateTime startDateTime, DateTime endDateTime)
        {
            var result = await _statManager.GetAllMatchByPlayerIdAndDateAsync(playerId, startDateTime, endDateTime);

            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<Match>, List<MatchResponse>>(result.EntityList), result.Count));
        }

    }
}