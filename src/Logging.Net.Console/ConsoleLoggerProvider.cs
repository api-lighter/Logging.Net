using Logging.Net.Core;
using Logging.Net.Serilog;
using Microsoft.Extensions.DependencyInjection;

namespace Logging.Net.Console
{
    public static class ConsoleLoggerProvider
    {
        public static IServiceCollection AddConsoleLogging(this IServiceCollection services)
        {
            services.AddSingleton<ILogger>(new ConsoleLogger());
            return services;
        }
    }
}
