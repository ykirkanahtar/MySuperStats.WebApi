using System;
using BasketballStats.WebApi.Helper;

namespace BasketballStats.WebApi.Utils
{
    public static class ApiConstants
    {
        /****Authorization Constants****/
        public const string ClientCode = "clientcode";
        public const string ClientPassword = "clientpassword";
        public const string InvalidGrant = "invalid_grant";
        public const string TokentEndPoint = "/token";
        public const string ApiRequest = "ApiRequest";
        /*******************************/

        /****Config Constants****/
        public const string ConfigEnvironment = "Environment";
        public const string ConfigDevEnvironment = "Dev";
        public const string ConfigTestEnvironment = "Test";
        /************************/

        public const string PublicSchema = "public";

        public const string ApiResourceFileName = "ApiResource";
        public const string DefaultRoute = "api/";
        public const string AdminRoute = DefaultRoute + "admin/";

        public static readonly string ApplicationEnvironment = ConfigHelper.GetConfigurationValue("AppSettings:ApplicationEnvironment");

        public static readonly int DefaultListCount = Convert.ToInt32(ConfigHelper.GetConfigurationValue("AppSettings:DefaultListCount") ?? "50");

    }
}
