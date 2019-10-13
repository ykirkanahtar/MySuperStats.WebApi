
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;
using MySuperStats.WebUI.Utils;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Pages
{
    public class PlayersModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        public readonly ISession _session;
        public List<PlayerResponse> Players { get; set; }

        public PlayersModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            Players = new List<PlayerResponse>();
        }

        public async Task OnGet(int id, string culture)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetAllPlayersByMatchGroupId, id)}";
            var response = await _webApiConnector.GetAsync(getUrl, culture, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Players = JsonConvert.DeserializeObject<List<PlayerResponse>>(response.Result.ToString());
            }
            else
                throw new Exception(response.Message);
        }
    }
}
