
using System;
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
    public class TopBasketballStatsModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        public readonly ISession _session;

        public BasketballStatisticTable StatisticTable { get; set; }

        public TopBasketballStatsModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            StatisticTable = new BasketballStatisticTable();
        }

        public async Task OnGet(int id, string culture)
        {
            try
            {
                var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetTopBasketballStats, id)}";
                var response = await _webApiConnector.GetAsync(getUrl, culture, SessionUtil.GetToken(_session));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StatisticTable = JsonConvert.DeserializeObject<BasketballStatisticTable>(response.Result.ToString());
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
