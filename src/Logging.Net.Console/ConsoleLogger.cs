using Logging.Net.Core;
using Logging.Net.Core.Logger;

namespace Logging.Net.Console
{
    public class ConsoleLogger : AbstractLogger
    {
        public override void WriteToLog(LogLevel logLevel, Message message)
        {
            if (IsLogLevelEnabled(logLevel))
            {
                System.Console.WriteLine($"{message.Time.ToString("dd/MM/yyyy HH:mm:ss zzz")} [{logLevel.ToString()}, Request: {message.RequestId?.ToString() ?? "None"}, Operation: {message.OperationName ?? "None"}, Caller: {message.OperationOwner ?? "None"}]: {message.MessageText}");
            }
        }
    }
}
