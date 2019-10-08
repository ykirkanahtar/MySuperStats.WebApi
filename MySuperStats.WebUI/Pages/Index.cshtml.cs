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
    public class IndexModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        public readonly ISession _session;

        public UserDetailWithBasketballStatResponse PlayerStats { get; set; }
        public List<BasketballStatResponse> BasketballStats { get; set; }

        [BindProperty]
        public List<SelectListItem> MatchGroups { get; set; }

        public IndexModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            PlayerStats = new UserDetailWithBasketballStatResponse();
            MatchGroups = new List<SelectListItem>();

            InitializePage();
        }

        private void InitializePage()
        {
            try
            {
                var loggedUser = SessionUtil.GetLoggedUser(_session);
                var getUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetAllMatchGroupsByUserId}{loggedUser.Id}";
                var response = _webApiConnector.Get(getUrl, SessionUtil.GetToken(_session));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var matchGroups = JsonConvert.DeserializeObject<List<MatchGroupResponse>>(response.Result.ToString());
                    MatchGroups = matchGroups.Select(a =>
                        new SelectListItem
                        {
                            Value = a.Id.ToString(),
                            Text = a.GroupName,
                        }).OrderBy(a => a.Text).ToList();
                }
                else
                    throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task OnGet()
        {
            try
            {
                var loggedPlayer = SessionUtil.GetLoggedUser(_session).Player;

                var getUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetPlayerWithBasketballStats}{loggedPlayer.Id}";
                var response = await _webApiConnector.GetAsync(getUrl, SessionUtil.GetToken(_session));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    PlayerStats = JsonConvert.DeserializeObject<UserDetailWithBasketballStatResponse>(response.Result.ToString());
                    BasketballStats = PlayerStats.Player.BasketballStats.OrderBy(p => p.Match.MatchDate).ThenBy(p => p.Match.Order).ToList();
                }
                else
                    throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }     
    }
}
