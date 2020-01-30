using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CustomFramework.BaseWebApi.Contracts.ApiContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;
using MySuperStats.WebUI.Utils;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Pages
{
    public class MatchesModel : PageModel
    {
        private readonly IWebApiConnector<WebApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        public readonly ISession _session;

        public List<MatchResponse> MatchList { get; set; }

        public MatchesModel(ISession session, IWebApiConnector<WebApiResponse> webApiConnector, AppSettings appSettings)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            MatchList = new List<MatchResponse>();
        }

        public async Task OnGet(int id, string culture)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetAllMacthesForMainScreen, id)}";
            var response = await _webApiConnector.GetAsync(getUrl, culture, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                MatchList = JsonConvert.DeserializeObject<List<MatchResponse>>(response.Result.ToString());
            }
            else
                throw new Exception(response.Message);
        }
    }
}
