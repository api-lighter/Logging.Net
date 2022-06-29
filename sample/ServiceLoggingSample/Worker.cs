using Logging.Net.Core;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceLoggingSample
{
    public class Worker : BackgroundService
    {
        private readonly ILogger _logger;

        public Worker(ILogger logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.Context.BeginContext();

            while (!stoppingToken.IsCancellationRequested)
            {

                _logger.Info($"Worker running at: {DateTimeOffset.Now}");
                await Task.Delay(500, stoppingToken);
            }
        }
    }
}
