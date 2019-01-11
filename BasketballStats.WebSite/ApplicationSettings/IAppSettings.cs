namespace BasketballStats.WebSite.ApplicationSettings
{
    public interface IAppSettings
    {
        string ApiUrl { get; set; }
        string TokenUrl { get; set; }
        Credentials Credentials { get; set; }
    }
}