using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BasketballStats.WebSite.Utils
{

    public class WebApiConnector : IWebApiConnector
    {
        private readonly string _apiUrl = ConfigHelper.GetConfigurationValue("AppSettings:ApiUrl");

        public async Task<WebApiResponse> GetAsync(string getUrl, string token = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                if (token != null)
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var response = await client.GetAsync(getUrl);
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WebApiResponse>(jsonData);
            }
        }

        public async Task<WebApiResponse> PostAsync(string requestPath, string jsonContent, string token = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                if (token != null)
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(requestPath, httpContent);
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WebApiResponse>(jsonData);
            }
        }

        private async Task<string> GetApiTokenAsync()
        {
            return await GetApiTokenAsync(
                ConfigHelper.GetConfigurationValue("AppSettings:DefaultWebPageUserMail")
                , ConfigHelper.GetConfigurationValue("AppSettings:DefaultWebPageUserPassword")
            );
        }

        private async Task<string> GetApiTokenAsync(string email, string password)
        {
            using (var client = new HttpClient())
            {
                var clientCode = ConfigHelper.GetConfigurationValue("AppSettings:WebPageClientCode");
                var clientPassword = ConfigHelper.GetConfigurationValue("AppSettings:WebPageClientPassword");

                //setup client
                client.BaseAddress = new Uri(_apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var loginClient = new LoginClient()
                {
                    ClientApplicationCode = clientCode,
                    ClientApplicationPassword = clientPassword,
                    Email = email,
                    Password = password,
                };

                var jsonContent = JsonConvert.SerializeObject(loginClient);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                //send request
                var responseMessage = await client.PostAsync("api/token", httpContent);

                //get access token from response body
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseJson);
                return jObject.GetValue("result").ToString();
            }
        }
    }
}