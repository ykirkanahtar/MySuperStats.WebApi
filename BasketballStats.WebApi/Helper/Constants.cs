using System;

namespace BasketballStats.WebApi.Helper
{
    public class Constants
    {
        /****Config Constants****/
        public const string ConfigEnvironment = "Environment";
        public const string ConfigDevEnvironment = "Dev";
        public const string ConfigTestEnvironment = "Test";
        /************************/

        public const string ApiResourceFileName = "ApiResource";
        public const string DefaultRoute = "api/";
        public const string AdminRoute = DefaultRoute + "admin/";

        public static readonly string ApplicationEnvironment = ConfigHelper.GetConfigurationValue("AppSettings:ApplicationEnvironment");

        public static readonly int DefaultListCount = Convert.ToInt32(ConfigHelper.GetConfigurationValue("AppSettings:DefaultListCount"));
    }
}