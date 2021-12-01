using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace Berger.Global.Extensions.Config
{
    public static class ConfigExtension
    {
        public static IConfigurationBuilder SetConfig(this IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);

            builder.AddEnvironmentVariables();

            return builder;
        }
        public static IConfigurationBuilder SetConfig(this IConfiguration configuration, IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", false, true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            builder.AddEnvironmentVariables();

            return builder;
        }

        public static T Parse<T>(this IConfigurationSection section)
        {
            return section.Get<T>();
        }
    }
}