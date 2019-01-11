using Newtonsoft.Json;

namespace BasketballStats.WebSite.ApplicationSettings
{
    public class Credentials
    {
        public int ApplicationId { get; set; }
        public string ClientApplicationCode { get; set; }
        public string ClientApplicationPassword { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
