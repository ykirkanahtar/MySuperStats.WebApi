﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
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
using Newtonsoft.Json.Linq;

namespace MySuperStats.WebUI.Pages
{
    public class PlayerPermissionsModel : PageModel
    {
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        public readonly ISession _session;
        public List<MatchGroupUserResponse> MatchGroupUsers { get; set; }


        public class UserRoleForGrid
        {
            public int id { get; set; }
            public int userid { get; set; }
            public int roleid { get; set; }
            public string name { get; set; }
            public string role { get; set; }
        }

        public PlayerPermissionsModel(ISession session, IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings)
        {
            _session = session;
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            MatchGroupUsers = new List<MatchGroupUserResponse>();
        }

        public JsonResult OnGetLoggedUserId()
        {
            var user = SessionUtil.GetLoggedUser(_session);
            return new JsonResult(user.Id);
        }

        public async Task<JsonResult> OnPostFromGridAsync(int id)
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
                        var request = JsonConvert.DeserializeObject<UserRoleForGrid>(requestBody);
                        if (request != null)
                        {
                            var newRoleEnum = (RoleEnum)Enum.Parse(typeof(RoleEnum), request.role);

                            var matchGroupUserRequest = new MatchGroupUserRequest
                            {
                                MatchGroupId = id,
                                UserId = request.userid,
                                RoleId = (int)newRoleEnum,
                            };

                            return await UpdateUserRoleAsync(matchGroupUserRequest);
                        }
                    }
                }
            }
            return new JsonResult(retValue);
        }

        private async Task<JsonResult> UpdateUserRoleAsync(MatchGroupUserRequest request)
        {

            var jsonContent = JsonConvert.SerializeObject(request);

            var postUrl = $"{_appSettings.WebApiUrl}{ApiUrls.MatchGroupUserUpdateRole}";
            var response = await _webApiConnector.PutAsync(postUrl, jsonContent, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return new JsonResult(HttpStatusCode.OK.ToString());
            }
            else if(response.StatusCode == HttpStatusCode.BadRequest)
            {
                return new JsonResult(response.Message);
            }
            else return new JsonResult("Bir hata oluştu");
        }

        public async Task<JsonResult> OnGetRoles(int id)
        {
            var getUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetAllMatchGroupUsersByMatchGroupId}{id}";
            var response = await _webApiConnector.GetAsync(getUrl, SessionUtil.GetToken(_session));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                MatchGroupUsers = JsonConvert.DeserializeObject<List<MatchGroupUserResponse>>(response.Result.ToString());

                var jsonResult = new List<UserRoleForGrid>();
                foreach (var matchGroupUser in MatchGroupUsers)
                {
                    jsonResult.Add(new UserRoleForGrid
                    {
                        id = matchGroupUser.Id,
                        userid = matchGroupUser.User.Id,
                        roleid = matchGroupUser.Role.Id,
                        name = $"{matchGroupUser.User.FirstName} {matchGroupUser.User.Surname}",
                        role = matchGroupUser.Role.Name
                    });
                }

                return new JsonResult(jsonResult);
            }
            else
                throw new Exception(response.Message);
        }
    }
}