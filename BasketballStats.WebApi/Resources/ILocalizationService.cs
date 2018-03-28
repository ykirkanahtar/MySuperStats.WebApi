using Microsoft.Extensions.Localization;

namespace BasketballStats.WebApi.Resources
{
    public interface ILocalizationService
    {
        LocalizedString GetValue(string key);
    }
}