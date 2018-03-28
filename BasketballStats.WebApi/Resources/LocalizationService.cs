using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BasketballStats.WebApi.Resources;
using Microsoft.Extensions.Localization;

namespace BasketballStats.WebApi.Resources
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

        public LocalizedString GetValue(string key)
        {
            return _localizer[key];
        }
    }
}
