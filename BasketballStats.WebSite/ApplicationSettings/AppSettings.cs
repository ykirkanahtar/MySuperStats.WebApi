namespace BasketballStats.WebSite.ApplicationSettings
{
    public class AppSettings : IAppSettings
    {
        public AppSettings()
        {
            Credentials = new Credentials();
        }

        public string ApiUrl { get; set; }
        public string TokenUrl { get; set; }
        public Credentials Credentials { get; set; }
    }
}
