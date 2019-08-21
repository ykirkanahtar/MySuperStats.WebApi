using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;
using MySuperStats.WebUI.Utils;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Pages
{
    public class StatisticEntryModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        public readonly ISession _session;


        [BindProperty]
        public MatchRequest MatchRequest { get; set; }
        //public MatchRequestForMultiStats MatchRequestForStatsEntry { get; set; }


        [BindProperty]
        public MatchResponse MatchResponse { get; set; }


        [BindProperty]
        public BasketballStatRequest StatRequest { get; set; }

        [BindProperty]
        public BasketballStatResponse StatResponse { get; set; }


        [BindProperty]
        [Range(1, int.MaxValue, ErrorMessage = "Zorunlu alan")]
        public int PlayerId { get; set; }

        [BindProperty]
        [Range(1, int.MaxValue, ErrorMessage = "Zorunlu alan")]
        public int TeamId { get; set; }

        public List<SelectListItem> TeamList { get; set; }
        public List<SelectListItem> PlayerList { get; set; }

        [BindProperty]
        public bool IsModalVisible { get; set; }


        public StatisticEntryModel(IHttpContextAccessor httpContextAccessor, ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            _mapper = mapper;

            StatRequest = new BasketballStatRequest();
            StatResponse = new BasketballStatResponse();

            //MatchRequestForStatsEntry = new MatchRequestForMultiStats();
            MatchRequest = new MatchRequest();
            MatchResponse = new MatchResponse();
            TeamList = new List<SelectListItem>();
            PlayerList = new List<SelectListItem>();

            InitializePage();
        }

        private TeamResponse GetHomeTeam()
        {
            return new TeamResponse { Id = 1, Name = "1.Takım" };
        }

        private TeamResponse GetAwayTeam()
        {
            return new TeamResponse { Id = 2, Name = "2.Takım" };
        }

        private void InitializePage()
        {
            var teams = new List<TeamResponse>
            {
                GetHomeTeam(),
                GetAwayTeam(),
            };

            TeamList = teams.Select(a =>
                              new SelectListItem
                              {
                                  Value = a.Id.ToString(),
                                  Text = a.Name
                              }).OrderBy(a => a.Text).ToList();

            MatchRequest.MatchDate = DateTime.Now.AddDays(-1);
            MatchRequest.Order = 1;

            StatRequest.OnePoint = 0;
            StatRequest.MissingOnePoint = 0;

            var getUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetAllUsersByMatchGroupId}{TempConst.DefaultMatchGroupId}";
            var response = _webApiConnector.GetAsync(getUrl, SessionUtil.GetToken(_session)).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var players = JsonConvert.DeserializeObject<List<UserResponse>>(response.Result.ToString());
                PlayerList = players.Select(a =>
                                        new SelectListItem
                                        {
                                            Value = a.Id.ToString(),
                                            Text = $"{a.FirstName} {a.Surname}"
                                        }).OrderBy(a => a.Text).ToList();
            }
            else
                throw new Exception(response.Message);

            OnGetMatchDetailAsync().Wait();
        }

        // public async Task<IActionResult> OnPostAsync()
        // {
        //     {
        //         MemoryStream stream = new MemoryStream();
        //         Request.Body.CopyTo(stream);
        //         stream.Position = 0;
        //         using (StreamReader reader = new StreamReader(stream))
        //         {
        //             string requestBody = reader.ReadToEnd();
        //             if (requestBody.Length > 0)
        //             {
        //                 Stats = JsonConvert.DeserializeObject<BasketballStatResponse>(requestBody);
        //                 var playerBasketballStatsResponse = new PlayerBasketballStatsResponse
        //                 {
        //                     BasketballStat = Stats,
        //                     Player = await GetPlayerByIdAsync(Stats.UserId),
        //                 };

        //                 var matchDetail = new MatchDetailBasketballStatsResponse();
        //                 var matchDetailJson = HttpContext.Session.GetString("MatchDetail") as string;
        //                 if (!string.IsNullOrEmpty(matchDetailJson)) matchDetail = JsonConvert.DeserializeObject<MatchDetailBasketballStatsResponse>(matchDetailJson);

        //                 if (Stats.TeamId == 1)
        //                 {
        //                     matchDetail.HomeTeamBasketballStats.PlayerBasketballStats.Add(playerBasketballStatsResponse);
        //                 }
        //                 else if (Stats.TeamId == 2)
        //                 {
        //                     matchDetail.AwayTeamBasketballStats.PlayerBasketballStats.Add(playerBasketballStatsResponse);
        //                 }
        //                 else
        //                     throw new Exception("Takım seçmediniz");

        //                 MatchDetail = matchDetail;
        //                 HttpContext.Session.SetString("MatchDetail", JsonConvert.SerializeObject(matchDetail));
        //             }
        //         }
        //     }
        //     return OnGetMatchDetail();
        // }

        private void GetMatchDetailFromSession()
        {
            var matchJson = _httpContextAccessor.HttpContext.Session.GetString("StatisticEntryForBasketballMatch") as string;
            if (!string.IsNullOrEmpty(matchJson)) MatchRequest = JsonConvert.DeserializeObject<MatchRequest>(matchJson);
        }

        private void SetMatchRequestSession()
        {
            _httpContextAccessor.HttpContext.Session.SetString("StatisticEntryForBasketballMatch", JsonConvert.SerializeObject(MatchRequest));
        }

        public async Task<IActionResult> OnPostAddStatsToTableAsync()
        {

            IsModalVisible = true;
            if (!ModelState.IsValid)
            {
                var errors = ModelStateHelper.GetErrorListFromModelState(ModelState);
                return Page();
            }

            try
            {
                if (!(TeamId > 0)) throw new ValidationException("Takım seçmediniz");
                if (!(PlayerId > 0)) throw new ValidationException("Oyuncu seçmediniz");
                if (StatRequest.CheckNegativeValue().Count > 0) throw new Exception("İstatistik değerleri negatif sayı olamaz");

                MatchRequest.HomeTeam = Mapper.Map<TeamRequest>(GetHomeTeam());
                MatchRequest.HomeTeamId = GetHomeTeam().Id;
                MatchRequest.AwayTeam = Mapper.Map<TeamRequest>(GetAwayTeam());
                MatchRequest.AwayTeamId = GetAwayTeam().Id;

                StatRequest.TeamId = TeamId;
                StatRequest.UserId = PlayerId;

                StatResponse = Mapper.Map<BasketballStatResponse>(StatRequest);
                StatResponse.User = await GetPlayerByIdAsync(PlayerId);

                GetMatchDetailFromSession();

                await SetMatchResponseAsync();

                if (TeamId == 1)
                {
                    CheckDuplicatePlayerStats(MatchResponse.HomeTeam.BasketballStats);
                    MatchResponse.HomeTeam.BasketballStats.Add(StatResponse);
                }
                else if (TeamId == 2)
                {
                    CheckDuplicatePlayerStats(MatchResponse.AwayTeam.BasketballStats);
                    MatchResponse.AwayTeam.BasketballStats.Add(StatResponse);
                }
                else
                {
                    throw new Exception("Takım Seçmediniz");
                }

                MatchRequest = Mapper.Map<MatchRequest>(MatchResponse);

                SetMatchRequestSession();
                IsModalVisible = false;
            }
            catch (ValidationException ex)
            {
                ViewData.ModelState.AddModelError("ModelErrors", ex.Message);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostSaveMatchAsync()
        {
            var matchDate = MatchRequest.MatchDate;
            var order = MatchRequest.Order;
            var durationInMinutes = MatchRequest.DurationInMinutes;
            var videoLink = MatchRequest.VideoLink;

            GetMatchDetailFromSession();

            MatchRequest.MatchGroupId = 1;
            MatchRequest.MatchDate = matchDate;
            MatchRequest.Order = order;
            MatchRequest.DurationInMinutes = durationInMinutes;
            MatchRequest.VideoLink = videoLink;

            var jsonContent = JsonConvert.SerializeObject(MatchRequest);

            var postUrl = $"{_appSettings.WebApiUrl}{ApiUrls.CreateMultiBasketballStats}";
            var response = await _webApiConnector.PostAsync(postUrl, jsonContent, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var matchId = JsonConvert.DeserializeObject<int>(response.Result.ToString());
                return Redirect($"MatchDetail/{matchId}");
            }
            else
                throw new Exception(response.Message);
        }

        private void CheckDuplicatePlayerStats(ICollection<BasketballStatResponse> basketballStats)
        {
            var playerHasAlreadyStatsInTeam = (from p in basketballStats
                                               where p.UserId == PlayerId
                                               && p.TeamId == TeamId
                                               select p).ToList().Count();
            if (playerHasAlreadyStatsInTeam > 0)
            {
                throw new ValidationException("Bu oyuncu bu takıma daha önceden eklenmiş");
            }
        }

        private async Task<UserResponse> GetPlayerByIdAsync(int id)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetUserById}{id}";
            var response = await _webApiConnector.GetAsync(getUrl, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var player = JsonConvert.DeserializeObject<UserResponse>(response.Result.ToString());
                return player;
            }
            else
                throw new Exception(response.Message);
        }

        public async Task OnGetMatchDetailAsync()
        {
            var matchRequestJson = _httpContextAccessor.HttpContext.Session.GetString("StatisticEntryForBasketballMatch") as string;
            if (!string.IsNullOrEmpty(matchRequestJson))
            {
                MatchRequest = JsonConvert.DeserializeObject<MatchRequest>(matchRequestJson);
                await SetMatchResponseAsync();
            }
        }

        public async Task SetMatchResponseAsync()
        {
            MatchResponse = Mapper.Map<MatchResponse>(MatchRequest);

            foreach (var stat in MatchResponse.HomeTeam.BasketballStats)
            {
                stat.User = await GetPlayerByIdAsync(stat.UserId);
            }
            foreach (var stat in MatchResponse.AwayTeam.BasketballStats)
            {
                stat.User = await GetPlayerByIdAsync(stat.UserId);
            }
        }
    }
}
