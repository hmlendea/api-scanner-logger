using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NuciLog;
using NuciLog.Core;

namespace ApiScannerLogger
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigurations(
            this IServiceCollection services,
            IConfiguration configuration)
            => services.AddNuciLoggerSettings(configuration);

        public static IServiceCollection AddCustomServices(this IServiceCollection services) => services
            .AddScoped<ILogger, NuciLogger>();
    }
}
