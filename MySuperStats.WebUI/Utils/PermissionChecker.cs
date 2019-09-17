using System;
using System.Net;
using System.Threading.Tasks;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
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
        private readonly IWebApiConnector<ApiResponse> _webApiConnector;
        private readonly AppSettings _appSettings;
        public readonly ISession _session;

        public PermissionChecker(IWebApiConnector<ApiResponse> webApiConnector, AppSettings appSettings, ISession session)
        {
            _webApiConnector = webApiConnector;
            _appSettings = appSettings;
            _session = session;
        }

        public async Task<bool> HasPermissionAsync(int matchGroupId, int userId, PermissionEnum permissionEnum)
        {
            var permissionArray = $"permissions={permissionEnum.ToString()}";
            var permissionGetUrl = $"{_appSettings.WebApiUrl}{ApiUrls.GetPermissions}userId/{userId}/matchGroupId/{matchGroupId}?{permissionArray}";
            var permissionResponse = await _webApiConnector.GetAsync(permissionGetUrl, SessionUtil.GetToken(_session));
            if (permissionResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(permissionResponse.Message);
            }
            var permissions = JsonConvert.DeserializeObject<PermissionCheckerResponse>(permissionResponse.Result.ToString());
            return Functions.GetPermissionValue(permissions.PermissionDetails, permissionEnum.ToString());
        }
    }
}