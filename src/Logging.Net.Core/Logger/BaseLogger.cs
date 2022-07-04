using Logging.Net.Core.Context;
using Logging.Net.Core.Formatters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Logging.Net.Core.Logger
{
    public class BaseLogger : ILoggerBase
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly LoggerContextData _context;

        public LoggerContextData Context => _context;

        public BaseLogger()
        {
            _jsonSerializerSettings = new JsonSerializerSettings();
            _jsonSerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            _context = new LoggerContextData();
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
            var newMessage = new Message(Context, message.FormatMessage(FormatType.None), logLevel);
            WriteToLog(logLevel, newMessage);
        }

        public virtual void WriteToLog(LogLevel logLevel, Message message)
        {
            WriteToLog(logLevel, JsonConvert.SerializeObject(message, _jsonSerializerSettings));
        }

        public virtual void WriteToLog(LogLevel logLevel, string message)
        {
            if (IsLogLevelEnabled(logLevel))
                Console.WriteLine(message);
        }
    }
}
