using Logging.Net.Core.Context;
using System;

namespace Logging.Net.Core
{
    internal class Message : LoggerContext
    {
        public LogLevel Level { get; set; }
        public DateTime Time { get; set; }
        public string MessageText { get; set; }

        public Message()
        {
            Time = DateTime.UtcNow;
            OperationId = Guid.NewGuid().ToString();
            RequestId = Guid.NewGuid();
            OperationName = "";
            User = "";
        }

        public Message(string messageText, LogLevel level)
        {
            MessageText = messageText;
            Time = DateTime.UtcNow;
            OperationId = Guid.NewGuid().ToString();
            RequestId = Guid.NewGuid();
            OperationName = "";
            User = "";
            Level = level;
        }

        public Message(Guid requestId, string messageText)
        {
            MessageText = messageText;
            RequestId = requestId;
            Time = DateTime.UtcNow;
            OperationId = Guid.NewGuid().ToString();
            OperationName = "";
            User = "";
        }

        public Message(DateTime time, string messageText)
        {
            Time = time;
            MessageText = messageText;
            OperationId = Guid.NewGuid().ToString();
            RequestId = Guid.NewGuid();
            OperationName = "";
            User = "";
        }
    }
}
