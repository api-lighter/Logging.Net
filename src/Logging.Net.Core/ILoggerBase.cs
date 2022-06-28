using Logging.Net.Core.Context;
using System.Collections.Generic;

namespace Logging.Net.Core
{
    public interface ILoggerBase
    {
        LoggerContext Context { get; }
        bool IsLogLevelEnabled(LogLevel logLevel);
        void Log(LogLevel logLevel, string message);
        void Log(LogLevel logLevel, KeyValuePair<string, object>[] data);
    }
}
