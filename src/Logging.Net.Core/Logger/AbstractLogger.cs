using System;
using System.Collections.Generic;

namespace Logging.Net.Core.Logger
{
    public abstract class AbstractLogger : BaseLogger, ILogger
    {
        public void Debug(string message)
        {
            Log(LogLevel.Debug, message);
        }

        public void Debug(KeyValuePair<string, object>[] data)
        {
            Log(LogLevel.Debug, data);
        }

        public void Error(string message)
        {
            Log(LogLevel.Error, message);
        }

        public void Error(KeyValuePair<string, object>[] data)
        {
            Log(LogLevel.Error, data);
        }

        public void Error(Exception exception)
        {
            Log(LogLevel.Error, exception.Message);
        }

        public void Fatal(string message)
        {
            Log(LogLevel.Fatal, message);
        }

        public void Fatal(KeyValuePair<string, object>[] data)
        {
            Log(LogLevel.Fatal, data);
        }

        public void Fatal(Exception exception)
        {
            Log(LogLevel.Fatal, exception.Message);
        }

        public void Info(string message)
        {
            Log(LogLevel.Info, message);
        }

        public void Info(KeyValuePair<string, object>[] data)
        {
            Log(LogLevel.Info, data);
        }

        public void Trace(string message)
        {
            Log(LogLevel.Trace, message);
        }

        public void Trace(KeyValuePair<string, object>[] data)
        {
            Log(LogLevel.Trace, data);
        }

        public void Warn(string message)
        {
            Log(LogLevel.Warn, message);
        }

        public void Warn(KeyValuePair<string, object>[] data)
        {
            Log(LogLevel.Warn, data);
        }

        public void Warn(Exception exception)
        {
            Log(LogLevel.Warn, exception.Message);
        }
    }
}
