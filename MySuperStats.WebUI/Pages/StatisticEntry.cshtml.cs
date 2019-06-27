
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;
using MySuperStats.WebUI.Utils;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Pages
{
    public class StatisticEntryModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        public readonly ISession _session;

        public UserDetailResponse PlayerStats { get; set; }

        [BindProperty]
        public MatchDetailBasketballStatsResponse MatchDetail { get; set; }

        public List<SelectListItem> Teams { get; set; }
        public List<SelectListItem> Players { get; set; }

        public StatisticEntryModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            MatchDetail = new MatchDetailBasketballStatsResponse();
            Teams = new List<SelectListItem>();
            Players = new List<SelectListItem>();
        }

        public async Task OnGet()
        {
            var teams = new List<TeamResponse>
            {
                new TeamResponse { Id = 0, Name = "Takım Seçiniz" },
                new TeamResponse { Id = 1, Name = "1.Takım" },
                new TeamResponse { Id = 2, Name = "2.Takım" },
            };

            Teams = teams.Select(a =>
                              new SelectListItem
                              {
                                  Value = a.Id.ToString(),
                                  Text = a.Name
                              }).ToList();

                


            var id = 1;
            var getUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetMatchDetail}{id}";
            var response = await _webApiConnector.GetAsync(getUrl, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                MatchDetail = JsonConvert.DeserializeObject<MatchDetailBasketballStatsResponse>(response.Result.ToString());
            }
            else
                throw new Exception(response.Message);
        }
    }
}
