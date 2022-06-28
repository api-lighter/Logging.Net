using Logging.Net.Core.Context;
using Logging.Net.Core.Formatters;
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
            WriteFormatted(logLevel, message);
        }

        public virtual void Log(LogLevel logLevel, KeyValuePair<string, object>[] data)
        {
            WriteFormatted(logLevel, JsonConvert.SerializeObject(data));
        }

        private void WriteFormatted(LogLevel logLevel, string message)
        {
            WriteToLog(logLevel, message.FormatMessage(FormatType.Date | FormatType.Time));
        }

        public virtual void WriteToLog(LogLevel logLevel, string message)
        {
            if (IsLogLevelEnabled(logLevel))
                Console.WriteLine(message);
        }
    }
}
