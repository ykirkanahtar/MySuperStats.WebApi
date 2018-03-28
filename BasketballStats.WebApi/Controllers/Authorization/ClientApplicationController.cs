using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    [Route(ApiConstants.AdminRoute + "clientapplication")]
    public class ClientApplicationController : Controller
    {
        private readonly IClientApplicationManager _clientApplicationManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<ClientApplicationController> _logger;
        private readonly IMapper _mapper;

        public ClientApplicationController(IClientApplicationManager clientApplicationManager, ILocalizationService localizationService, ILogger<ClientApplicationController> logger, IMapper mapper)
        {
            _clientApplicationManager = clientApplicationManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        [Permission(Entity.ClientApplication, Crud.Create)]
        public async Task<IActionResult> Create([FromBody] ClientApplicationRequest request)
        {
            var result = await _clientApplicationManager.CreateAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<ClientApplication, ClientApplicationResponse>(result)));
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(Entity.ClientApplication, Crud.Update)]
        public async Task<IActionResult> UpdateClientApplicationName(int id, [FromBody] ClientApplicationUpdateRequest request)
        {
            var result = await _clientApplicationManager.UpdateClientApplicationAsync(id, request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<ClientApplication, ClientApplicationResponse>(result)));
        }

        [Route("{id:int}/update/clientapplicationpassword")]
        [HttpPut]
        [AllowAnonymous]
        [Permission(Entity.ClientApplication, Crud.Update)]
        public async Task<IActionResult> UpdateClientApplicationPassword(int id, [FromBody] string clientApplicationPassword)
        {
            var result = await _clientApplicationManager.UpdateClientApplicationPasswordAsync(id, clientApplicationPassword);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<ClientApplication, ClientApplicationResponse>(result)));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(Entity.ClientApplication, Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientApplicationManager.DeleteAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(true));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(Entity.ClientApplication, Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _clientApplicationManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<ClientApplication, ClientApplicationResponse>(result)));
        }

        [Route("get/clientapplicationcode/{clientapplicationcode}")]
        [HttpGet]
        [Permission(Entity.ClientApplication, Crud.Select)]
        public async Task<IActionResult> GetByClientApplicationCode(string clientapplicationcode)
        {
            var result = await _clientApplicationManager.GetByClientApplicationCodeAsync(clientapplicationcode);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<ClientApplication, ClientApplicationResponse>(result)));
        }
    }
}
