using System.IO;
using Microsoft.Extensions.Configuration;

namespace BasketballStats.WebSite.Utils
{
    public static class ConfigHelper
    {
        private static IConfigurationRoot Configuration { get; set; }

        public static string GetConfigurationValue(string key)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            return Configuration[key];
        }
    }
}