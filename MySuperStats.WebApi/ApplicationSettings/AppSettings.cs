using CS.Common.EmailProvider;
using CustomFramework.Authorization.Utils;

namespace MySuperStats.WebApi.ApplicationSettings
{
    public class AppSettings : IAppSettings
    {
        public AppSettings()
        {
            Token = new Token();
            EmailConfig = new EmailConfig();
        }

        public string AppName { get; set; }
        public bool SendConfirmationEmail { get; set; }
        public string SenderEmailAddress { get; set; }
        public int DefaultListCount { get; set; }
        public int IterationCountForHashing { get; set; }
        public Token Token { get; set; }
        public EmailConfig EmailConfig { get; set; }
    }
}