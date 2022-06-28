using System;
using System.Collections.Generic;

namespace Logging.Net.Core
{
    public interface ILogger : ILoggerBase
    {
        void Trace(string message);
        void Trace(KeyValuePair<string, object>[] data);
        void Debug(string message);
        void Debug(KeyValuePair<string, object>[] data);
        void Info(string message);
        void Info(KeyValuePair<string, object>[] data);
        void Warn(string message);
        void Warn(KeyValuePair<string, object>[] data);
        void Warn(Exception exception);
        void Error(string message);
        void Error(KeyValuePair<string, object>[] data);
        void Error(Exception exception);
        void Fatal(string message);
        void Fatal(KeyValuePair<string, object>[] data);
        void Fatal(Exception exception);
    }
}
