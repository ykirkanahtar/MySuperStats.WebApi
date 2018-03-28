using System.IO;
using Microsoft.Extensions.Configuration;

namespace BasketballStats.WebApi.Helper
{
    public static class ConfigHelper
    {
        private static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            return builder.Build();
        }

        public static string GetConfigurationValue(string key)
        {
            return GetConfiguration()[key];
        }

        public static IConfiguration GetSection(string key)
        {
            return GetConfiguration().GetSection(key);
        }
    }
}