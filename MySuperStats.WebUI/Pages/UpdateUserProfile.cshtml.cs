
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Contracts.Resources;
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
    public class UpdateUserProfileModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        public readonly ISession _session;
        private readonly ILocalizationService _localizer;

        private readonly IMapper _mapper;


        [BindProperty]
        public UserUpdateRequest UserUpdate { get; set; }

        [BindProperty]
        public UserEmailUpdateRequest EmailUpdateRequest { get; set; }

        [BindProperty]
        public string Token { get; set; }


        public UpdateUserProfileModel(IMapper mapper, ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings, ILocalizationService localizer)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            _mapper = mapper;
            UserUpdate = new UserUpdateRequest();
            EmailUpdateRequest = new UserEmailUpdateRequest();
            _localizer = localizer;
        }

        public async Task OnGet()
        {
            var user = SessionUtil.GetLoggedUser(_session);
            var getUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetUserById}{user.Id}";
            var response = await _webApiConnector.GetAsync(getUrl, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var userResponse = JsonConvert.DeserializeObject<UserResponse>(response.Result.ToString());
                UserUpdate = _mapper.Map<UserUpdateRequest>(userResponse);
                UserUpdate.BirthDate = UserUpdate.BirthDate.Date;
                EmailUpdateRequest.NewEmail = userResponse.Email;
            }
            else
                throw new Exception(response.Message);
        }

        public JsonResult OnGetLocalizedValue(string value)
        {
            return new JsonResult($"{_localizer.GetValue(value)}");
        }

        public async Task<IActionResult> OnPostUpdateProfile()
        {
            var user = SessionUtil.GetLoggedUser(_session);
            var jsonContent = JsonConvert.SerializeObject(UserUpdate);
            var postUrl = $"{_appSettings.WebApiUrl}User/{user.Id}/update";
            var response = await _webApiConnector.PutAsync(postUrl, jsonContent, SessionUtil.GetToken(_session));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                _session.Set("User", Encoding.UTF8.GetBytes(response.Result.ToString()));
                return Redirect($"../UserProfile");
            }
            else
                ViewData.ModelState.AddModelError("ModelErrors", response.Message);

            return Page();
        }

        public async Task<JsonResult> OnPostUpdateEmail()
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
                        var emailUpdateRequest = new UserEmailUpdateRequest
                        {
                            NewEmail = requestBody,
                        };
                        return await OnEmailUpdateRequestAsync(emailUpdateRequest);
                    }
                }
            }
            return new JsonResult(retValue);
        }

        private async Task<JsonResult> OnEmailUpdateRequestAsync(UserEmailUpdateRequest request)
        {
            var user = SessionUtil.GetLoggedUser(_session);
            var jsonContent = JsonConvert.SerializeObject(request);

            var postUrl = $"{_appSettings.WebApiUrl}User/{user.Id}/update/email/request";
            var response = await _webApiConnector.PutAsync(postUrl, jsonContent, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return new JsonResult(HttpStatusCode.OK.ToString());
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return new JsonResult(response.Message);
            }
            else return new JsonResult(_localizer.GetValue("AnErrorHasOccured"));
        }
    }
}
