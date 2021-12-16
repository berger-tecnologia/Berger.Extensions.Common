using System;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;

namespace Berger.Extensions.Common.Globalization
{
    public static class CultureExtension
    {
        public static void SetCulture(this IServiceCollection services, string name)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var culture = new CultureInfo(name);

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}