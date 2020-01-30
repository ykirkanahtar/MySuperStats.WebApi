using System;
using System.Net;
using System.Threading.Tasks;
using CustomFramework.BaseWebApi.Contracts.ApiContracts;
using Microsoft.AspNetCore.Http;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.Constants;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Utils
{

    public class PermissionChecker : IPermissionChecker
    {
        private readonly IWebApiConnector<WebApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        public readonly ISession _session;

        public PermissionChecker(IWebApiConnector<WebApiResponse> webApiConnector, AppSettings appSettings, ISession session)
        {
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            _session = session;
        }

        public async Task<bool> HasPermissionAsync(int matchGroupId, int userId, PermissionEnum permissionEnum, string culture)
        {
            var permissionArray = $"permissions={permissionEnum.ToString()}";
            var permissionGetUrl = $"{_appSettings.WebApiUrl}{String.Format(ApiUrls.GetPermissions, userId, matchGroupId, permissionArray)}";
            var permissionResponse = await _webApiConnector.GetAsync(permissionGetUrl, culture, SessionUtil.GetToken(_session));
            if (permissionResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(permissionResponse.Message);
            }
            var permissions = JsonConvert.DeserializeObject<PermissionCheckerResponse>(permissionResponse.Result.ToString());
            return Functions.GetPermissionValue(permissions.PermissionDetails, permissionEnum.ToString());
        }
    }
}