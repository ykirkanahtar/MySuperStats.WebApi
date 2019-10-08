using System.Reflection;
using Microsoft.Extensions.Localization;
using CustomFramework.WebApiUtils.Contracts.Resources;

namespace MySuperStats.Contracts.Resources
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IStringLocalizer _localizer;

        public LocalizationService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResources);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("SharedResources", assemblyName.Name);
        }

        public string GetValue(string key)
        {
            return _localizer[key].Value;
        }
    }
}
