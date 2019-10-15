
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
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
        public UpdatePlayerRequest PlayerUpdate { get; set; }

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
            PlayerUpdate = new UpdatePlayerRequest();
            EmailUpdateRequest = new UserEmailUpdateRequest();
            _localizer = localizer;
        }

        public async Task OnGet(string culture)
        {
            var user = SessionUtil.GetLoggedUser(_session);
            var getUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetUserById, user.Id)}";
            var response = await _webApiConnector.GetAsync(getUrl, culture, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var userResponse = JsonConvert.DeserializeObject<UserResponse>(response.Result.ToString());
                PlayerUpdate = _mapper.Map<UpdatePlayerRequest>(userResponse.Player);
                PlayerUpdate.BirthDate = PlayerUpdate.BirthDate.Date;
                EmailUpdateRequest.NewEmail = userResponse.Email;
            }
            else
                throw new Exception(response.Message);
        }

        public JsonResult OnGetLocalizedValue(string value)
        {
            return new JsonResult($"{_localizer.GetValue(value)}");
        }

        public async Task<IActionResult> OnPostUpdateProfile(string culture)
        {
            var user = SessionUtil.GetLoggedUser(_session);
            var jsonContent = JsonConvert.SerializeObject(PlayerUpdate);
            var postUrl = $"{_appSettings.WebApiUrl}{String.Format(Constants.ApiUrls.UpdatePlayer, user.Player.Id)}";
            var response = await _webApiConnector.PutAsync(postUrl, jsonContent, culture, SessionUtil.GetToken(_session));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var playerResponse = JsonConvert.DeserializeObject<PlayerResponse>(response.Result.ToString());
                user.Player = playerResponse;
                _session.SetString("User", JsonConvert.SerializeObject(user));
                return Redirect($"../{culture}/UserProfile");
            }
            else
                ViewData.ModelState.AddModelError("ModelErrors", response.Message);

            return Page();
        }

        public async Task<JsonResult> OnPostUpdateEmail(string culture)
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
                        return await OnEmailUpdateRequestAsync(culture, emailUpdateRequest);
                    }
                }
            }
            return new JsonResult(retValue);
        }

        private async Task<JsonResult> OnEmailUpdateRequestAsync(string culture, UserEmailUpdateRequest request)
        {
            var user = SessionUtil.GetLoggedUser(_session);
            var jsonContent = JsonConvert.SerializeObject(request);

            var postUrl = $"{_appSettings.WebApiUrl}{String.Format(Constants.ApiUrls.UpdateEmailRequest, user.Id)}";
            var response = await _webApiConnector.PutAsync(postUrl, jsonContent, culture, SessionUtil.GetToken(_session));

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
