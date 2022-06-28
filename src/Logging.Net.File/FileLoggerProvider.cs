using Logging.Net.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Net.File
{
    public static class ConsoleLoggerProvider
    {
        public static IServiceCollection AddFileLogging(this IServiceCollection services)
        {
            services.AddSingleton<ILogger>(new FileLogger());
            return services;
        }
    }
}
