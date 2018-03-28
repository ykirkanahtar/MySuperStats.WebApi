using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BasketballStats.WebApi.Authorization;
using BasketballStats.WebApi.Authorization.Business.Contracts;
using BasketballStats.WebApi.Authorization.Enums;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Authorization.Response;
using BasketballStats.WebApi.Resources;
using BasketballStats.WebApi.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BasketballStats.WebApi.Controllers.Authorization
{
    [Route(ApiConstants.AdminRoute + "claim")]
    public class ClaimController : Controller
    {
        private readonly IClaimManager _claimManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<ClaimController> _logger;
        private readonly IMapper _mapper;

        public ClaimController(IClaimManager claimManager, ILocalizationService localizationService, ILogger<ClaimController> logger, IMapper mapper)
        {
            _claimManager = claimManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        [Permission(Entity.Claim, Crud.Create)]
        public async Task<IActionResult> Create([FromBody] ClaimRequest request)
        {
            var result = await _claimManager.CreateAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Claim, ClaimResponse>(result)));
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(Entity.Claim, Crud.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] ClaimRequest request)
        {
            var result = await _claimManager.UpdateAsync(id, request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Claim, ClaimResponse>(result)));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(Entity.Claim, Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            await _claimManager.DeleteAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(true));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(Entity.Claim, Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _claimManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Claim, ClaimResponse>(result)));
        }

        [Route("get/customclaim/{customclaim}")]
        [HttpGet]
        [Permission(Entity.Claim, Crud.Select)]
        public async Task<IActionResult> GetByCustomClaim(CustomClaim customClaim)
        {
            var result = await _claimManager.GetByCustomClaimAsync(customClaim);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Claim, ClaimResponse>(result)));
        }

        [Route("getall")]
        [HttpGet]
        [Permission(Entity.Claim, Crud.Select)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _claimManager.GetAllAsync();
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<List<Claim>, List<ClaimResponse>>(result.EntityList),
                result.Count));
        }
    }
}
