
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class PlayerDetailModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        public readonly ISession _session;

        public UserDetailWithBasketballStatResponse PlayerStats { get; set; }
        public List<BasketballStatResponse> BasketballStats { get; set; }

        public PlayerDetailModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            PlayerStats = new UserDetailWithBasketballStatResponse();
        }

        public async Task OnGet(int id)
        {
            try
            {
                var getUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetPlayerWithBasketballStats}{id}";
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
