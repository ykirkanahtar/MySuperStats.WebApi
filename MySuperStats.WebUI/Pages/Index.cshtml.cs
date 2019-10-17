using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Contracts.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;
using MySuperStats.WebUI.Utils;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        private readonly ISession _session;
        private readonly ILocalizationService _localizer;

        public UserDetailWithBasketballStatResponse PlayerBasketballStats { get; set; }
        public UserDetailWithFootballStatResponse PlayerFootballStats { get; set; }
        public List<BasketballStatResponse> BasketballStats { get; set; }
        public List<FootballStatResponse> FootballStats { get; set; }


        [BindProperty]
        public List<SelectListItem> MatchGroups { get; set; }

        [BindProperty]
        public int MatchGroupId { get; set; }

        [BindProperty]
        public MatchGroupResponse MatchGroup { get; set; }

        [BindProperty]
        public PlayerResponse Player { get; set; }

        public IndexModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings, ILocalizationService localizer)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            PlayerBasketballStats = new UserDetailWithBasketballStatResponse();
            PlayerFootballStats = new UserDetailWithFootballStatResponse();
            MatchGroups = new List<SelectListItem>();

            InitializePage();
            _localizer = localizer;
        }

        private void InitializePage()
        {
            try
            {
                var loggedUser = SessionUtil.GetLoggedUser(_session);
                var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetAllMatchGroupsByUserId, loggedUser.Id)}";
                var cultureName = Thread.CurrentThread.CurrentCulture.Name;
                var response = _webApiConnector.Get(getUrl, cultureName, SessionUtil.GetToken(_session));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var matchGroups = JsonConvert.DeserializeObject<List<MatchGroupResponse>>(response.Result.ToString());
                    MatchGroups = matchGroups.Select(a =>
                        new SelectListItem
                        {
                            Value = a.Id.ToString(),
                            Text = a.GroupName,
                        }).OrderBy(a => a.Text).ToList();
                    if (matchGroups.Count > 0)
                    {
                        var defaultMatchGroupId = _session.GetInt32("DefaultMatchGroupId");
                        if (defaultMatchGroupId != null)
                            MatchGroupId = (int)defaultMatchGroupId;
                        else
                            MatchGroupId = matchGroups[0].Id;
                    }
                }
                else
                    throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task OnGet(string culture)
        {
            try
            {
                Player = SessionUtil.GetLoggedUser(_session).Player;

                if (MatchGroups.Count == 0)
                {
                    TempData["ErrorMessage"] = _localizer.GetValue("You are not a member of an match group yet");
                    return;
                }

                var matchGroupGetUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetMatchGroupById, MatchGroupId)}";
                var response = await _webApiConnector.GetAsync(matchGroupGetUrl, culture, SessionUtil.GetToken(_session));
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    MatchGroup = JsonConvert.DeserializeObject<MatchGroupResponse>(response.Result.ToString());
                }
                else
                    throw new Exception(response.Message);

                if (MatchGroup.MatchGroupType == MatchGroupType.Basketball)
                {
                    var basketballStatsGetUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetPlayerWithBasketballStats, Player.Id, MatchGroupId)}";
                    var basketballStatsResponse = await _webApiConnector.GetAsync(basketballStatsGetUrl, culture, SessionUtil.GetToken(_session));

                    if (basketballStatsResponse.StatusCode == HttpStatusCode.OK)
                    {
                        PlayerBasketballStats = JsonConvert.DeserializeObject<UserDetailWithBasketballStatResponse>(basketballStatsResponse.Result.ToString());
                        BasketballStats = PlayerBasketballStats.Player.BasketballStats.OrderBy(p => p.Match.MatchDate).ThenBy(p => p.Match.Order).ToList();
                    }
                    else
                        throw new Exception(basketballStatsResponse.Message);
                }
                else if (MatchGroup.MatchGroupType == MatchGroupType.Football)
                {
                    var footballStatsGetUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetPlayerWithFootballStats, Player.Id, MatchGroupId)}";
                    var footballStatsResponse = await _webApiConnector.GetAsync(footballStatsGetUrl, culture, SessionUtil.GetToken(_session));

                    if (footballStatsResponse.StatusCode == HttpStatusCode.OK)
                    {
                        PlayerFootballStats = JsonConvert.DeserializeObject<UserDetailWithFootballStatResponse>(footballStatsResponse.Result.ToString());
                        FootballStats = PlayerFootballStats.Player.FootballStats.OrderBy(p => p.Match.MatchDate).ThenBy(p => p.Match.Order).ToList();
                    }
                    else
                        throw new Exception(footballStatsResponse.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult OnPostSelectMatchGroup()
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
                            var matchGroupResponse = JsonConvert.DeserializeObject<MatchGroupResponse>(requestBody);
                            if (matchGroupResponse.Id > 0)
                            {
                                _session.SetInt32("DefaultMatchGroupId", matchGroupResponse.Id);
                                return new JsonResult("Ok");
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
    }
}
