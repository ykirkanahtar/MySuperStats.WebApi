using CS.Common.EmailProvider;
using CustomFramework.Authorization.Utils;

namespace MySuperStats.WebApi.ApplicationSettings
{
    public interface IAppSettings
    {
        string AppName { get; set; }
        bool SendConfirmationEmail { get; set; }
        string SenderEmailAddress { get; set; }
        int DefaultListCount { get; set; }
        int IterationCountForHashing { get; set; }
        Token Token { get; set; }
        EmailConfig EmailConfig { get; set; }
    }
}