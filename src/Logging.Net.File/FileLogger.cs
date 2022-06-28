using Logging.Net.Core;
using Logging.Net.Core.Logger;
using System;

namespace Logging.Net.File
{
    public class FileLogger : AbstractLogger
    {
        const string DefaultFileName = "Log";
        const string DefaultFileExtension = "log";

        private readonly string _fileName;

        private object _lock = new object();

        public FileLogger(string fileName = null)
        {
            _fileName = string.IsNullOrEmpty(fileName) ? $"{DefaultFileName}.{DefaultFileExtension}" : fileName;
        }

        public override void WriteToLog(LogLevel logLevel, string message)
        {
            base.WriteToLog(logLevel, message);

            if (IsLogLevelEnabled(logLevel))
            {
                lock (_lock)
                {
                    using var streamWriter = System.IO.File.AppendText(_fileName);
                    streamWriter.WriteLine(message);
                }
            }
        }
    }
}
