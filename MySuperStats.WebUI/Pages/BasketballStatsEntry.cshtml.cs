
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.BaseWebApi.Contracts.ApiContracts;
using CustomFramework.BaseWebApi.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySuperStats.Contracts.Enums;
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
        private readonly IWebApiConnector<WebApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        public readonly ISession _session;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizer;

        public List<PlayerResponse> Players { get; set; }

        [BindProperty]
        public CreateMatchRequestWithMultiBasketballStats Model { get; set; }

        public UniqueCheckerForCreateMatch UniqueChecker { get; set; }

        public class GridForTeamSelect
        {
            public int playerid { get; set; }
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

        public BasketballStatsEntryModel(ISession session, IWebApiConnector<WebApiResponse> webApiConnector, AppSettings appSettings, IMapper mapper, ILocalizationService localizer)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            _mapper = mapper;

            Players = new List<PlayerResponse>();

            Model = new CreateMatchRequestWithMultiBasketballStats();
            Model.MatchRequest.Order = 1;
            Model.MatchRequest.MatchDate = DateTime.Now.AddDays(-1).Date;
            _localizer = localizer;
        }

        public JsonResult OnGetLocalizedValue(string value)
        {
            return new JsonResult($"{_localizer.GetValue(value)}");
        }

        public async Task OnGetAsync(int id, string culture)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetMatchGroupById, id)}";
            var response = await _webApiConnector.GetAsync(getUrl, culture, SessionUtil.GetToken(_session));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var matchGroupResponse = JsonConvert.DeserializeObject<MatchGroupResponse>(response.Result.ToString());
                if (matchGroupResponse.MatchGroupType != MatchGroupType.Basketball)
                {
                    throw new ArgumentException(_localizer.GetValue("This group is just for basketball stats"));
                }
            }
            else
                throw new Exception(response.Message);
        }

        public async Task<JsonResult> OnGetPlayers(int id, string culture)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetAllPlayersByMatchGroupId, id)}";
            var response = await _webApiConnector.GetAsync(getUrl, culture, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Players = JsonConvert.DeserializeObject<List<PlayerResponse>>(response.Result.ToString());
                var gridData = new List<GridForTeamSelect>();

                foreach (var player in Players)
                {
                    gridData.Add(new GridForTeamSelect
                    {
                        playerid = player.Id,
                        name = $"{player.FirstName} {player.LastName}",
                        haschecked = null
                    });
                }
                return new JsonResult(gridData);
            }
            else
                throw new Exception(response.Message);
        }

  public async Task<IActionResult> OnPostCheckMatchIsUniqueAsync(int id, string culture)
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
                            var request = JsonConvert.DeserializeObject<UniqueCheckerForCreateMatch>(requestBody);
                            if (request != null)
                            {
                                request.MatchDate = Convert.ToDateTime(request.MatchDateString);
                                return await OnGetMatchGroupIdMatchDateAndOrderAreUniqueAsync(id, culture, request);
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

        public async Task<JsonResult> OnGetMatchGroupIdMatchDateAndOrderAreUniqueAsync(int id, string culture, UniqueCheckerForCreateMatch uniqueChecker)
        {
            var jsonContent = JsonConvert.SerializeObject(uniqueChecker);

            var postUrl = $"{_appSettings.WebApiUrl}{ApiUrls.MatchGroupIdMatchDateAndOrderAreUnique}";

            var response = await _webApiConnector.PostAsync(postUrl, jsonContent, culture, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = (bool)response.Result;
                return new JsonResult(result);
            }
            else
                throw new Exception(response.Message);
        }        

        private TeamResponse GetHomeTeam()
        {
            return new TeamResponse { Id = 1, TeamName = _localizer.GetValue("FirstTeam") };
        }

        private TeamResponse GetAwayTeam()
        {
            return new TeamResponse { Id = 2, TeamName = _localizer.GetValue("SecondTeam") };
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
                                var matchDate = Convert.ToDateTime(request.MatchDate);
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

        public async Task<JsonResult> OnPostSaveMatchAsync(int id, string culture)
        {
            var jsonContent = JsonConvert.SerializeObject(Model);

            var postUrl = $"{_appSettings.WebApiUrl}{ApiUrls.CreateMultiBasketballStats}";
            var response = await _webApiConnector.PostAsync(postUrl, jsonContent, culture, SessionUtil.GetToken(_session));

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
            else
            {
                return new JsonResult(_localizer.GetValue("AnErrorHasOccured"));
            }
        }
    }
}
