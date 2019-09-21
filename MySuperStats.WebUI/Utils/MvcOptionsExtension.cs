using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Resources;

namespace MySuperStats.WebUI.Utils
{
    public static class MvcOptionsExtension
    {
        /// <summary>
        /// localize ModelBinding messages, e.g. when user enters string value instead of number...
        /// these messages can't be localized like data attributes
        /// </summary>
        /// <param name="mvc"></param>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IMvcBuilder AddModelBindingMessagesLocalizer
            (this IMvcBuilder mvc, IServiceCollection services)
        {
            return mvc.AddMvcOptions(o =>
            {
                var type = typeof(SharedResources);
                var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
                var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                var localizer = factory.Create("SharedResources", assemblyName.Name);

                o.ModelBindingMessageProvider
                    .SetAttemptedValueIsInvalidAccessor((x, y) => localizer["'{0}' is not valid value for '{0}' field", x, y]);

                o.ModelBindingMessageProvider
                    .SetValueMustBeANumberAccessor((x) => localizer["'{0}' must be a number", x]);
            });
        }
    }
}