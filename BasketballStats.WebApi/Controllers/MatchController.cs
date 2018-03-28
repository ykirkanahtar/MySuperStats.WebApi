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
    [Route(ApiConstants.DefaultRoute + "match")]
    public class MatchController : Controller
    {
        private readonly IMatchManager _matchManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<MatchController> _logger;
        private readonly IMapper _mapper;

        public MatchController(IMatchManager matchManager, ILocalizationService localizationService, ILogger<MatchController> logger, IMapper mapper)
        {
            _matchManager = matchManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        [Permission(Entity.Match, Crud.Create)]
        public async Task<IActionResult> Create([FromBody] MatchRequest request)
        {
            var result = await _matchManager.CreateAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Match, MatchResponse>(result)));
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(Entity.Match, Crud.Update)]
        public async Task<IActionResult> UpdateName(int id, [FromBody] MatchRequest request)
        {
            var result = await _matchManager.UpdateAsync(id, request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Match, MatchResponse>(result)));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(Entity.Match, Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            await _matchManager.DeleteAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(true));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _matchManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Match, MatchResponse>(result)));
        }

        [Route("getall/startdate/{startdate}/enddate/{enddate}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllByDate(DateTime startDateTime, DateTime endDateTime)
        {
            var result = await _matchManager.GetAllByDateAsync(startDateTime, endDateTime);

            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<Match>, List<MatchResponse>>(result.EntityList), result.Count));
        }

        [Route("getall")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var result = await _matchManager.GetAllAsync();

            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<Match>, List<MatchResponse>>(result.EntityList), result.Count));
        }
    }
}