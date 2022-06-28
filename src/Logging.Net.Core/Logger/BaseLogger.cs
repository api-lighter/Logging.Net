using Logging.Net.Core.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Logging.Net.Core.Logger
{
    public class BaseLogger : ILoggerBase
    {
        private readonly LoggerContext _context;

        public LoggerContext Context => _context;

        public BaseLogger()
        {
            _context = new LoggerContext();
        }

        public virtual bool IsLogLevelEnabled(LogLevel logLevel) => true;

        public virtual void Log(LogLevel logLevel, string message)
        {
            if (IsLogLevelEnabled(logLevel))
                Console.WriteLine(message);
        }

        public virtual void Log(LogLevel logLevel, KeyValuePair<string, object>[] data)
        {
            if (IsLogLevelEnabled(logLevel))
                Console.WriteLine(JsonConvert.SerializeObject(data));
        }
    }
}
