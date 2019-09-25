using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MySuperStats.WebUI.Areas.Identity.IdentityHostingStartup))]
namespace MySuperStats.WebUI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}