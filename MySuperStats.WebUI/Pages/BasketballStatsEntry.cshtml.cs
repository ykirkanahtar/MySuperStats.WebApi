
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;
using MySuperStats.WebUI.Utils;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Pages
{
    public class BasketballStatsEntryModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        public readonly ISession _session;
        private readonly IMapper _mapper;

        public List<UserResponse> Players { get; set; }

        [BindProperty]
        public CreateMatchRequestWithMultiBasketballStats Model { get; set; }

        public class GridForTeamSelect
        {
            public int userid { get; set; }
            public string name { get; set; }
            public bool? haschecked { get; set; }
        }

        public class GridStatsEntry
        {
            public string MatchDate { get; set; }
            public int Order { get; set; }
            public int DurationInMinutes { get; set; }
            public string VideoLink { get; set; }
            public List<BasketballStatRequestForMultiEntry> FirstTeamStats { get; set; }
            public List<BasketballStatRequestForMultiEntry> SecondTeamStats { get; set; }
        }

        public BasketballStatsEntryModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings, IMapper mapper)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            _mapper = mapper;

            Players = new List<UserResponse>();

            Model = new CreateMatchRequestWithMultiBasketballStats();
            Model.MatchRequest.Order = 1;
            Model.MatchRequest.MatchDate = DateTime.Now.AddDays(-1).Date;
        }

        public async Task<JsonResult> OnGetPlayers(int id)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetAllUsersByMatchGroupId}{id}";
            var response = await _webApiConnector.GetAsync(getUrl, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Players = JsonConvert.DeserializeObject<List<UserResponse>>(response.Result.ToString());
                var gridData = new List<GridForTeamSelect>();

                foreach (var player in Players)
                {
                    gridData.Add(new GridForTeamSelect
                    {
                        userid = player.Id,
                        name = $"{player.FirstName} {player.Surname}",
                        haschecked = null
                    });
                }
                return new JsonResult(gridData);
            }
            else
                throw new Exception(response.Message);
        }

        private TeamResponse GetHomeTeam()
        {
            return new TeamResponse { Id = 1, TeamName = "1.Takım" };
        }

        private TeamResponse GetAwayTeam()
        {
            return new TeamResponse { Id = 2, TeamName = "2.Takım" };
        }

        public async Task<IActionResult> OnPostFromGridAsync(int id, string culture)
        {
            try
            {

                var retValue = false;
                {
                    var stream = new MemoryStream();
                    Request.Body.CopyTo(stream);
                    stream.Position = 0;
                    using (var reader = new StreamReader(stream))
                    {
                        string requestBody = reader.ReadToEnd();
                        if (requestBody.Length > 0)
                        {
                            var request = JsonConvert.DeserializeObject<GridStatsEntry>(requestBody);
                            if (request != null)
                            {
                                Model.MatchRequest.MatchGroupId = id;
                                var matchDate = DateTime.ParseExact(request.MatchDate, "dd.MM.yyyy", CultureInfo.CurrentCulture);
                                Model.MatchRequest.MatchDate = matchDate;
                                Model.MatchRequest.Order = request.Order;
                                Model.MatchRequest.DurationInMinutes = request.DurationInMinutes;
                                Model.MatchRequest.VideoLink = request.VideoLink;

                                Model.MatchRequest.HomeTeamId = GetHomeTeam().Id;
                                Model.MatchRequest.AwayTeamId = GetAwayTeam().Id;

                                var homeTeamStats = request.FirstTeamStats;
                                foreach (var stat in homeTeamStats)
                                {
                                    Model.HomeTeamStats.Add(stat);
                                }

                                var awayTeamStats = request.SecondTeamStats;
                                foreach (var stat in awayTeamStats)
                                {
                                    Model.AwayTeamStats.Add(stat);
                                }

                                return await OnPostSaveMatchAsync(id, culture);
                            }
                        }
                    }
                }
                return new JsonResult(retValue);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        public async Task<IActionResult> OnPostSaveMatchAsync(int id, string culture)
        {
            var jsonContent = JsonConvert.SerializeObject(Model);

            var postUrl = $"{_appSettings.WebApiUrl}{ApiUrls.CreateMultiBasketballStats}";
            var response = await _webApiConnector.PostAsync(postUrl, jsonContent, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var matchId = JsonConvert.DeserializeObject<int>(response.Result.ToString());
                var redirectUrl = $"/{culture}/MatchDetail/{matchId}";
                return new JsonResult($"{HttpStatusCode.OK.ToString()}-{redirectUrl}");
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return new JsonResult(response.Message);
            }
            else return new JsonResult("Bir hata oluştu");
        }
    }
}
