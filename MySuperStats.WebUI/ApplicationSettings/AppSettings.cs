namespace MySuperStats.WebUI.ApplicationSettings
{
    public class AppSettings
    {
        public AppSettings()
        {
            Credentials = new Credentials();
        }

        public string WebApiUrl { get; set; }
        public Credentials Credentials { get; set; }
    }
}